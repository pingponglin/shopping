<template>
  <div>
    <!-- 面包屑导航区域 -->
    <el-breadcrumb separator-class="el-icon-arrow-right">
      <el-breadcrumb-item :to="{ path: '/shou' }">首页</el-breadcrumb-item>
      <el-breadcrumb-item>商品管理</el-breadcrumb-item>
      <el-breadcrumb-item>添加商品</el-breadcrumb-item>
    </el-breadcrumb>
    <!-- 卡片区域 -->
    <el-card>
      <el-alert
        title="添加商品信息"
        type="info"
        center
        show-icon
        :closable="false"
      >
      </el-alert>
      <el-form
        :model="updateform"
        label-width="100px"
        class="demo-ruleForm"
        :rules="updateformRules"
        ref="updateformref"
        style="height: 100%; width: 100%"
      >
        <el-form-item
          label="商品名称"
          style="position: relative; left: 0px; margin: 33px auto"
          prop="GoodName"
        >
          <el-input v-model="updateform.GoodName"></el-input>
        </el-form-item>
         <el-form-item
          label="商品标题"
          style="position: relative; left: 0px; margin: 33px auto"
          prop="GoodfuName"
        >
          <el-input v-model="updateform.GoodfuName"></el-input>
        </el-form-item>
        <el-form-item
          label="商品价格"
          style="position: relative; top: 0px; left: 0px"
          prop="GoodPrice"
        >
          <el-input v-model="updateform.GoodPrice"></el-input>
        </el-form-item>
        <el-form-item
          label="促销价"
          style="position: relative; top: 0px; left: 0px"
          prop="GoodPrcieper"
        >
          <el-input v-model="updateform.GoodPrcieper"></el-input>
        </el-form-item>
        <el-form-item
          label="商品库存"
          style="position: relative; top: 0px; left: 0px"
          prop="Goodnum"
        >
          <el-input v-model="updateform.Goodnum"></el-input>
        </el-form-item>
        <el-form-item
          label="商品图片"
          style="position: relative; top: 0px; left: 0px"
          prop="GoodImage"
        >
          <!-- <el-input v-model="updateform.GoodImage"></el-input> -->
           <el-upload
  class="upload-demo"
  action="http://81.68.132.153:7070/api/Food/Imgupload"
  :on-preview="handlePreview"
  :on-remove="handleRemove"
  :file-list="fileList"
  :on-success="handleSuccess"
  :limit="1"
  :before-upload="beforeAvatarUpload"
  list-type="picture">
  <el-button size="small" type="primary">点击上传</el-button>
  <div slot="tip" class="el-upload__tip">只能上传jpg/png文件，且不超过500kb</div>
</el-upload>
        </el-form-item>
        <el-form-item
          label="商品细节图片"
          style="position: relative; top: 0px; left: 0px"
          prop="GoodImage"
        >
          <!-- <el-input v-model="updateform.GoodImage"></el-input> -->
           <el-upload
  class="upload-demo"
  action="http://81.68.132.153:7070/api/Food/Imgupload"
  :file-list="fileList1"
  :on-success="handleSuccess1"
  :limit="5"
  :before-upload="beforeAvatarUpload"
  list-type="picture">
  <el-button size="small" type="primary">点击上传</el-button>
  <div slot="tip" class="el-upload__tip">只能上传jpg/png文件，且不超过500kb</div>
</el-upload>
        </el-form-item>
        <p style="margin-left: 400px">
          <el-button type="primary" @click="addtianj">添加</el-button
          ><el-button type="danger" @click="addquxiao" style="margin-left: 60px"
            >取消</el-button
          >
        </p>
      </el-form>
    </el-card>
  </div>
</template>

<script>
export default {
data(){
    return{
//查询到的商品信息对象
      updateform: {
        goodimage:""
      },
      //修改表单的验证规则
      updateformRules: {
        GoodName: [
          { required: true, message: "请输入商品名称", trigger: "blur" }
        ],
        GoodfuName: [
          { required: true, message: "请输入商品标题", trigger: "blur" }
        ],
        GoodPrice: [
          { required: true, message: "请输入商品价格", trigger: "blur" }
        ],
         GoodPrcieper: [
          { required: true, message: "请输入商品促销价", trigger: "blur" }
        ],
         Goodnum: [
          { required: true, message: "请输入商品库存", trigger: "blur" }
        ]
      },
      fileList:[],
      fileList1:[]
      ,
       //图片
       goodimagess:[]
    }
},
methods:{
//添加
addtianj(){
  this.$refs.updateformref.validate((valid) =>{
   if (valid) {
     this.$axios.post('/api/Food/gooadd',this.updateform).then(d=>{
  if (d.data=="添加成功") {
    this.$router.push('/goodsliebiao');
    this.$message.success('添加成功!');
    console.log(d.data);
  }
  else{
    this.$message.error('添加失败!')
  }
})
   }
   else{
     console.log('error submit!!');
            return false;
   }
  })
},
//取消
addquxiao(){
this.$router.push('/goodsliebiao');
},
 handleRemove(file, fileList) {
        console.log(file, fileList);
      },
      handlePreview(file) {
        console.log(file);
      }
      ,
      //上传成功
      handleSuccess(response,file,fileList){
console.log("上传文件夹名"+file.name);
this.updateform.GoodImage=file.name;
// console.log(fileList);
// let dd="";
// for (let i = 0; i < fileList.length; i++) {
//   if (i==fileList.length-1) {
//     dd+=fileList[i].name;
//     console.log(dd);
//   }else{
//     dd+=fileList[i].name+"/";
//     console.log(dd);}
// }
// this.updateform.GoodImage=dd;
      },
      handleSuccess1(response,file,fileList){
console.log(fileList);
let dd="";
for (let i = 0; i < fileList.length; i++) {
  if (i==fileList.length-1) {
    dd+=fileList[i].name;
    console.log(dd);
  }else{
    dd+=fileList[i].name+"/";
    console.log(dd);}
}
this.updateform.GoodImagefu=dd;
      },
      beforeAvatarUpload(file) {
      var testmsg = /^image\/(jpeg|png|jpg)$/.test(file.type);
      const isLt2M = file.size / 1024 / 1024 < 2;
      if (!testmsg) {
        this.$message.error("上传头像格式不正确");
      }
      if (!isLt2M) {
        this.$message.error("上传头像图片大小不能超过 2MB!");
      }
      return testmsg && isLt2M;
    }
}
,
created(){

}
}
</script>

<style>
.el-breadcrumb {
  margin-bottom: 15px;
  font-size: 12px;
}
.el-card {
  box-shadow: 0 1px 1px rgba(0, 0, 0, 0.15) !important;
  height: 100%;
}
.el-table {
  margin-top: 15px !important;
}
.el-form-item {
  margin-bottom: 41px !important;
}
@media screen and (min-width: 640px) {
  form,
  .am-cf,
  .partner {
    max-width: 1117px;
    margin: 0px auto;
  }
}
input[type=file] {
    display: none;
}
</style>