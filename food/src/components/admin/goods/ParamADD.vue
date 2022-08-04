<template>
  <div>
    <!-- 面包屑导航区域 -->
    <el-breadcrumb separator-class="el-icon-arrow-right">
      <el-breadcrumb-item :to="{ path: '/shou' }">首页</el-breadcrumb-item>
      <el-breadcrumb-item>商品属性</el-breadcrumb-item>
      <el-breadcrumb-item>添加属性</el-breadcrumb-item>
    </el-breadcrumb>
    <!-- 卡片区域 -->
    <el-card>
      <el-alert
        title="添加商品属性"
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
          label="生产许可证"
          style="position: relative; left: 0px; margin: 33px auto"
          prop="ParamProductionid"
        >
          <el-input v-model="updateform.ParamProductionid"></el-input>
        </el-form-item>
        <el-form-item
          label="储藏方法"
          style="position: relative; top: 0px; left: 0px"
          prop="Parammethod"
        >
          <el-input v-model="updateform.Parammethod"></el-input>
        </el-form-item>
        <el-form-item
          label="保质期"
          style="position: relative; top: 0px; left: 0px"
          prop="Paramdate"
        >
          <el-input v-model="updateform.Paramdate"></el-input>
        </el-form-item>
        <el-form-item
          label="食用方法"
          style="position: relative; top: 0px; left: 0px"
          prop="Paramedible"
        >
          <el-input v-model="updateform.Paramedible"></el-input>
        </el-form-item>
        <el-form-item
          label="产品规格"
          style="position: relative; top: 0px; left: 0px"
          prop="Paramcontent"
        >
          <el-input v-model="updateform.Paramcontent"></el-input>
        </el-form-item>
        <el-form-item
          label="产地"
          style="position: relative; top: 0px; left: 0px"
          prop="Paramproduct"
        >
          <el-input v-model="updateform.Paramproduct"></el-input>
        </el-form-item>
        <el-form-item
          label="产品标准号"
          style="position: relative; top: 0px; left: 0px"
          prop="Paramstandard"
        >
          <el-input v-model="updateform.Paramstandard"></el-input>
        </el-form-item>
        <el-form-item
          label="原料产地"
          style="position: relative; top: 0px; left: 0px"
          prop="Paramsite"
        >
          <el-input v-model="updateform.Paramsite"></el-input>
        </el-form-item>
        <el-form-item
          label="商品细节图片一"
          style="position: relative; top: 0px; left: 0px"
          prop="Paramcontent"
        >
          <el-upload
  class="upload-demo"
  action="http://81.68.132.153:7070/api/Food/Imgupload"
  :on-preview="handlePreview"
  :on-remove="handleRemove"
  :file-list="fileList"
  :on-success="handleSuccess1"
  :limit="1"
  list-type="picture">
  <el-button size="small" type="primary">点击上传</el-button>
  <div slot="tip" class="el-upload__tip">只能上传jpg/png文件，且不超过500kb</div>
</el-upload>
        </el-form-item>
        <el-form-item
          label="商品细节图片二"
          style="position: relative; top: 0px; left: 0px"
          prop="Paramcontent"
        >
           <el-upload
  class="upload-demo"
  action="http://81.68.132.153:7070/api/Food/Imgupload"
  :on-preview="handlePreview"
  :on-remove="handleRemove"
  :file-list="fileList"
  :on-success="handleSuccess2"
  :limit="1"
  list-type="picture">
  <el-button size="small" type="primary">点击上传</el-button>
  <div slot="tip" class="el-upload__tip">只能上传jpg/png文件，且不超过500kb</div>
</el-upload>
        </el-form-item>
        <el-form-item
          label="商品细节图片三"
          style="position: relative; top: 0px; left: 0px"
          prop="Paramcontent"
        >
           <el-upload
  class="upload-demo"
  action="http://81.68.132.153:7070/api/Food/Imgupload"
  :on-preview="handlePreview"
  :on-remove="handleRemove"
  :file-list="fileList"
  :on-success="handleSuccess3"
  :limit="1"
  list-type="picture">
  <el-button size="small" type="primary">点击上传</el-button>
  <div slot="tip" class="el-upload__tip">只能上传jpg/png文件，且不超过500kb</div>
</el-upload>
        </el-form-item>
        <el-form-item
          label="商品细节图片四"
          style="position: relative; top: 0px; left: 0px"
          prop="Paramcontent"
        >
           <el-upload
  class="upload-demo"
  action="http://81.68.132.153:7070/api/Food/Imgupload"
  :on-preview="handlePreview"
  :on-remove="handleRemove"
  :file-list="fileList"
  :on-success="handleSuccess4"
  :limit="1"
  list-type="picture">
  <el-button size="small" type="primary">点击上传</el-button>
  <div slot="tip" class="el-upload__tip">只能上传jpg/png文件，且不超过500kb</div>
</el-upload>
        </el-form-item>
         <el-form-item
          label="商品名称"
          style="position: relative; top: 0px; left: 0px"
          prop="Goodid"
        >
          <!-- <el-input v-model="updateform.Good.Goodname"></el-input> -->
          <el-select v-model="updateform.Goodid" placeholder="请选择">
    <el-option
      v-for="item in Good"
      :key="item.Goodid"
      :label="item.GoodName"
      :value="item.Goodid">
    </el-option>
  </el-select>
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
      updateform: {},
      //修改表单的验证规则
      updateformRules: {
        ParamProductionid: [
          { required: true, message: "请输入生产许可证编号", trigger: "blur" }
        ],
        Parammethod: [
          { required: true, message: "请输入储藏方法", trigger: "blur" }
        ],
         Paramdate: [
          { required: true, message: "请输入保质期", trigger: "blur" }
        ],
         Paramedible: [
          { required: true, message: "请输入食用方法", trigger: "blur" }
        ],
        Paramcontent: [
          { required: true, message: "请输入产品规格", trigger: "blur" }
        ]
        ,
        Paramproduct: [
          { required: true, message: "请输入产地", trigger: "blur" }
        ]
        ,
        Paramstandard: [
          { required: true, message: "请输入产品标准号", trigger: "blur" }
        ]
        ,
        Paramsite: [
          { required: true, message: "请输入原料产地", trigger: "blur" }
        ]
        ,
        DeailImageid: [
          { required: true, message: "请输入商品细节图片", trigger: "blur" }
        ]
        ,
        Goodid: [
          { required: true, message: "请输入商品名称", trigger: "blur" }
        ]
      },
       fileList: []
       ,
       //查询所有商品名称
       Good:[]
    }
},
methods:{
  //上传成功
      handleSuccess1(response,file,fileList){
console.log("上传文件夹名"+file.name);
this.updateform.Goodimage1=file.name;
      }
  ,
  //上传成功
      handleSuccess2(response,file,fileList){
console.log("上传文件夹名"+file.name);
this.updateform.Goodimage2=file.name;
      },
      //上传成功
      handleSuccess3(response,file,fileList){
console.log("上传文件夹名"+file.name);
this.updateform.Goodimage3=file.name;
      },
      //上传成功
      handleSuccess4(response,file,fileList){
console.log("上传文件夹名"+file.name);
this.updateform.Goodimage4=file.name;
      },
//添加
addtianj(){
  this.$refs.updateformref.validate((valid) =>{
   if (valid) {
     this.$axios.post('/api/Food/ParamADD',this.updateform).then(d=>{
  if (d.data=="添加成功") {
    this.$router.push('/goods/Param');
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
this.$router.push('/goods/Param');
},
goodlist(){
      this.$axios
      .get("/api/Food/goods")
      .then((s) => {
        this.Good = s.data;
        
        // this.tableData=s.data;
      })
      .catch({});
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
</style>