<template>
  <div>
       <!-- 面包屑导航区域 -->
    <el-breadcrumb separator-class="el-icon-arrow-right">
      <el-breadcrumb-item :to="{ path: '/shou' }">首页</el-breadcrumb-item>
      <el-breadcrumb-item>商品管理</el-breadcrumb-item>
      <el-breadcrumb-item>商品属性</el-breadcrumb-item>
    </el-breadcrumb>
    <!-- 卡片 -->
    <el-card>
         <el-button
                type="primary"
                @click="addDialog"
              >添加商品属性</el-button>
        <el-table :data="tableData" border stripe style="width: 100%">
        <el-table-column prop="Paramid" label="编号" width="100">
        </el-table-column>
        <el-table-column prop="ParamProductionid" label="生产许可证" width="190">
        </el-table-column>
        <el-table-column prop="Parammethod" label="储藏方法" width="190">
        </el-table-column>
        <el-table-column prop="Paramdate" label="保质期" width="100">
        </el-table-column>
        <el-table-column prop="Paramedible" label="食用方法" width="190">
        </el-table-column>
        <el-table-column prop="Paramcontent" label="产品规格" width="100">
        </el-table-column>
        <el-table-column prop="Paramproduct" label="产地" width="190">
        </el-table-column>
        <el-table-column prop="Paramstandard" label="产品标准号" width="150">
        </el-table-column>
        <el-table-column prop="Paramsite" label="原料产地" width="150">
        </el-table-column>
         <el-table-column prop="Goodimage1" label="商品细节图片一" width="190">
           <template v-slot="tableData">
            <img :src="'http://81.68.132.153:7070/img/'+tableData.row.Goodimage1" width="100"
              height="100" alt="">
           </template>
        </el-table-column>
         <el-table-column prop="Goodimage2" label="商品细节图片二" width="190">
             <template v-slot="tableData">
            <img :src="'http://81.68.132.153:7070/img/'+tableData.row.Goodimage2" width="100"
              height="100" alt="">
           </template>
        </el-table-column>
        <el-table-column prop="Goodimage3" label="商品细节图片三" width="190">
            <template v-slot="tableData">
            <img :src="'http://81.68.132.153:7070/img/'+tableData.row.Goodimage3" width="100"
              height="100" alt="">
           </template>
        </el-table-column>
         <el-table-column prop="Goodimage4" label="商品细节图片四" width="190">
             <template v-slot="tableData">
            <img :src="'http://81.68.132.153:7070/img/'+tableData.row.Goodimage4" width="100"
              height="100" alt="">
           </template>
        </el-table-column>
        <el-table-column prop="Good.GoodName" label="商品名称" width="230">
        </el-table-column>
        <el-table-column fixed="right" label="操作" width="164">
          <!-- 编辑用户 -->
          <template slot-scope="tableData">
            <el-tooltip
              effect="dark"
              content="编辑"
              placement="top"
              :enterable="false"
            >
              <el-button
                type="primary"
                icon="el-icon-edit"
                size="mini"
                @click="updateDialog(tableData.row.Paramid)"
              ></el-button>
            </el-tooltip>

            <!-- 删除用户 -->
            <el-button
              type="danger"
              icon="el-icon-delete"
              size="mini"
              @click="deleteUser(tableData.row.Paramid)"
            ></el-button>
          </template>
        </el-table-column>
      </el-table>
      <!-- 分页区域 -->
      <el-pagination
        @size-change="handleSizeChange"
        @current-change="handleCurrentChange"
        :current-page="pagenum"
        :page-sizes="[1, 2, 5, 10]"
        :page-size="pagesize"
        layout="total, sizes, prev, pager, next, jumper"
        :total="total"
      >
      </el-pagination>
    </el-card>
    <!-- 修改商品口味的对话框 -->
    <!-- @close关闭 -->
    <el-dialog
      title="修改用户"
      :visible.sync="updateVisible"
      width="50%"
    >
      <!-- :rules="updateformRules" ref="updateformRel" -->
     <el-form
        :model="updateform"
        label-width="100px"
        class="demo-ruleForm"
        style="height: 100%; width: 100%"
        :rules="updateformRules"
        ref="updateformref"
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
          prop="Goodimage1"
        >
          <el-input v-model="updateform.Goodimage1" disabled></el-input>
          <el-upload
  class="upload-demo"
  action="http://81.68.132.153:7070/api/Food/Imgupload"
  :file-list="fileList1"
  :on-success="handleSuccess1"
  :before-upload="beforeAvatarUpload"
  :limit="1"
  list-type="picture">
  <el-button size="small" type="primary">点击上传</el-button>
  <div slot="tip" class="el-upload__tip">只能上传jpg/png文件，且不超过500kb</div>
</el-upload>
        </el-form-item>
        <el-form-item
          label="商品细节图片二"
          style="position: relative; top: 0px; left: 0px"
          prop="Goodimage2"
        >
          <el-input v-model="updateform.Goodimage2" disabled></el-input>
          <el-upload
  class="upload-demo"
  action="http://81.68.132.153:7070/api/Food/Imgupload"
  :file-list="fileList2"
  :on-success="handleSuccess2"
  :before-upload="beforeAvatarUpload"
  :limit="1"
  list-type="picture">
  <el-button size="small" type="primary">点击上传</el-button>
  <div slot="tip" class="el-upload__tip">只能上传jpg/png文件，且不超过500kb</div>
</el-upload>
        </el-form-item>
        <el-form-item
          label="商品细节图片三"
          style="position: relative; top: 0px; left: 0px"
          prop="Goodimage3"
        >
          <el-input v-model="updateform.Goodimage3" disabled></el-input>
          <el-upload
  class="upload-demo"
  action="http://81.68.132.153:7070/api/Food/Imgupload"
  :file-list="fileList3"
  :on-success="handleSuccess3"
  :before-upload="beforeAvatarUpload"
  :limit="1"
  list-type="picture">
  <el-button size="small" type="primary">点击上传</el-button>
  <div slot="tip" class="el-upload__tip">只能上传jpg/png文件，且不超过500kb</div>
</el-upload>
        </el-form-item>
        <el-form-item
          label="商品细节图片四"
          style="position: relative; top: 0px; left: 0px"
          prop="Goodimage4"
        >
          <el-input v-model="updateform.Goodimage4" disabled></el-input>
          <el-upload
  class="upload-demo"
  action="http://81.68.132.153:7070/api/Food/Imgupload"
  :file-list="fileList4"
  :on-success="handleSuccess4"
  :before-upload="beforeAvatarUpload"
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
      </el-form>
      <span slot="footer" class="dialog-footer">
        <el-button @click="updateVisible = false">取 消</el-button>
        <el-button type="primary" @click="updateInfo">确 定</el-button>
      </span>
    </el-dialog>
  </div>
</template>

<script>
export default {
data(){
    return{
 //获取用户的数据
      tableData: [],
      //当前的页数
      pagenum: 1,
      //当前每页的数据
      pagesize: 5,
      //获取总共的页数
      total: 0,
       //控制修改对话框的显示与隐藏
      updateVisible: false,
      //查询到的商品信息对象
      updateform: {
        // Goodname:""
        
      },
      //修改表单的验证规则
      updateformRules: {
        
      },
      //接收所有商品
      Good:[],
      fileList1:[],
      fileList2:[],
      fileList3:[],
      fileList4:[]
    }
}
,
methods:{
    async paramiList() {
      this.$axios
        .get("/api/Food/Paramselect", {
          params: {
            pagenum: this.pagenum,
            pagesize: this.pagesize,
          },
        })
        .then((d) => {
          this.tableData = d.data;
          console.log(d.data);
        })
        .catch((l) => {
          console.log(l);
        });
    },
    //监听pagesize改变的事件
    handleSizeChange(newSieze) {
      console.log(newSieze + "pagesize=");
      this.pagesize = newSieze;
      this.paramiList();
    },
    //监听页码值改变的事件
    handleCurrentChange(newPage) {
      console.log(newPage + "pagenum");
      this.pagenum = newPage;
      this.paramiList();
    },
    //添加对话框
    async addDialog(){
this.$router.push('/goods/ParamADD');
    },
    //修改口味对话框
    async updateDialog(id) {
      this.updateVisible = true;
      console.log(id);
      this.$axios
        .get("/api/Food/Paramid", {
          params: {
            paramid: id,
          },
        })
        .then((dt) => {
          if (dt.data != "") {
            this.updateform = dt.data[0];
            // this.updateform.Good.Goodname=dt.data[0].Good.GoodName;
            console.log(this.updateform);
          } else {
            this.$message.error("查询用户信息失败");
          }
        })
        .catch((l) => {
          console.log(l);
        });
    },
    //修改口味并提交
    updateInfo() {
      this.$refs.updateformref.validate((valid) => {
        if (!valid) return;
        //发起数据请求
        this.$axios
          .post(
            "/api/Food/ParamUpdate",
             this.updateform
          )
          .then((d) => {
            if (d.data == "修改成功") {
              this.updateVisible = false;
              this.paramiList();
              
              console.log(d.data);
              return this.$message.success("更新用户信息成功!");
            } 
            else {
              return this.$message.error("更新用户信息失败!");
            }
          });
        console.log(valid);
      });
    },
    //删除
    deleteUser(id) {
      console.log(id);
      this.$confirm("此操作将永久删除该用户, 是否继续?", "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning",
      })
        .then(async () => {
          this.$axios
            .get("/api/Food/paramdelete", {
              params: {
                id: id,
              },
            })
            .then((d) => {
              if (d.data == "删除成功") {
                this.$message({
                  type: "success",
                  message: "删除成功!",
                });
                this.paramiList();
              } else {
                this.$message({
                  type: "success",
                  message: "删除失败!",
                });
              }
            })
            .catch((l) => {
              console.log(l);
            });
        })
        .catch(() => {
          this.$message({
            type: "info",
            message: "已取消删除",
          });
        });}
    ,
    //查询商品所有
    goodlist(){
      this.$axios
      .get("/api/Food/goods")
      .then((s) => {
        this.Good = s.data;
        
        // this.tableData=s.data;
      })
      .catch({});
    },
    //查询商品口味
     paramiss(){
      this.$axios
      .get("/api/Food/Params")
      .then(s => {
        this.total = s.data.length;
        // this.tableData=s.data;
        console.log("total"+this.total);
      })
      .catch({});
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
    },
    //上传成功
      handleSuccess1(response,file,fileList){
console.log("上传文件夹名"+file.name);
this.updateform.Goodimage1=file.name;
      },
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
      }
},
created() {
   this.paramiss();
    
    this.paramiList();
    this.goodlist();
    // this.getselect();
  },
}
</script>

<style scoped>
.el-breadcrumb {
  margin-bottom: 15px;
  font-size: 12px;
}
.el-card {
  box-shadow: 0 1px 1px rgba(0, 0, 0, 0.15) !important;
  height: 100%;
}
</style>