<template>
  <div>
    <el-breadcrumb separator-class="el-icon-arrow-right">
      <el-breadcrumb-item :to="{ path: '/shou' }">首页</el-breadcrumb-item>
      <el-breadcrumb-item>商品管理</el-breadcrumb-item>
      <el-breadcrumb-item>商品列表</el-breadcrumb-item>
    </el-breadcrumb>
    <!-- 卡片区域 -->
    <el-card>
      <!-- 搜索与添加区域 -->
      <el-row :gutter="20">
        <el-col :span="8">
          <el-input placeholder="请输入内容" v-model="query">
            <el-button
              slot="append"
              icon="el-icon-search"
              @click="getselect"
            ></el-button>
          </el-input>
        </el-col>
        <el-col :span="4">
          <el-button type="primary" @click="goAddpage">添加商品</el-button>
           <el-button type="primary" @click="getselectss">刷新</el-button>
        </el-col>
      </el-row>
      <!-- 用户列表区域 -->
      <el-table :data="tableData" border stripe style="width: 100%">
        <el-table-column prop="Goodid" label="商品编号" width="100">
        </el-table-column>
        <el-table-column prop="GoodName" label="商品名称" width="190">
        </el-table-column>
         <el-table-column prop="GoodfuName" label="商品标题" width="190">
        </el-table-column>
        <el-table-column prop="GoodImage" label="商品图片" width="170">
          <template v-slot="tableData">
            <img
              :src="'http://81.68.132.153:7070/img/'+tableData.row.GoodImage"
              width="100"
              height="100" style="width:100px"
            />
          </template>
        </el-table-column>
        <el-table-column prop="GoodPrice" label="商品价格" width="160">
        </el-table-column>
        <el-table-column prop="GoodPrcieper" label="商品促销价" width="150">
        </el-table-column>
        <el-table-column prop="Goodnum" label="商品库存" width="150">
        </el-table-column>
        <el-table-column prop="GoodCreatedate" label="创建时间" width="170">
          <template v-slot="tableData">
            {{ tableData.row.GoodCreatedate | dateFormat }}
          </template>
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
                @click="updateDialog(tableData.row.Goodid)"
              ></el-button>
            </el-tooltip>

            <!-- 删除用户 -->
            <el-button
              type="danger"
              icon="el-icon-delete"
              size="mini"
              @click="deleteUser(tableData.row.Goodid)"
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
    <!-- 修改用户的对话框 -->
    <!-- @close关闭 -->
    <el-dialog
      title="修改用户"
      :visible.sync="updateVisible"
      width="50%"
      @close="updateDialogClosed"
    >
      <!-- :rules="updateformRules" ref="updateformRel" -->
      <el-form
        :model="updateform"
        label-width="70px"
        class="demo-ruleForm"
        :rules="updateformRules"
        ref="updateformref"
      >
        <el-form-item
          label="商品名称"
          style="position: relative; top: 0px; left: 0px"
          prop="GoodName"
        >
          <el-input v-model="updateform.GoodName"></el-input>
        </el-form-item>
         <el-form-item
          label="商品标题"
          style="position: relative; top: 0px; left: 0px"
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
        <el-input v-model="updateform.GoodImage" disabled></el-input>
        <el-upload
  class="upload-demo"
  action="http://81.68.132.153:7070/api/Food/Imgupload"
  :file-list="fileList"
  :on-success="handleSuccess"
  :before-upload="beforeAvatarUpload"
  :limit="1"
  list-type="picture">
  <el-button size="small" type="primary">点击上传</el-button>
  <div slot="tip" class="el-upload__tip">只能上传jpg/png文件，且不超过500kb</div>
</el-upload>
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
  data() {
    return {
      //获取用户的数据
      tableData: [],
      //当前的页数
      pagenum: 1,
      //当前每页的数据
      pagesize: 5,
      //获取总共的页数
      total: 0,
      //获取搜索的内容
      query: "",
      //控制修改对话框的显示与隐藏
      updateVisible: false,
      //查询到的商品信息对象
      updateform: {},
      //修改表单的验证规则
      updateformRules: {

      },
      fileList:[],
      imgd:[]
    };
  },
  methods: {
    async getUserList() {
      this.$axios
        .get("/api/Food/goodsiddS", {
          params: {
            pagenum: this.pagenum,
            pagesize: this.pagesize,
          },
        })
        .then((d) => {
            this.tableData = d.data.data;
           this.total=d.data.total;
          this.imgd= d.data[5].GoodImage;
          console.log(d.data.GoodImage);
          console.log(d.data);
        })
        .catch((l) => {
          console.log(l);
        });
    },
    //查询
    async getselect() {
      this.$axios
        .get("/api/Food/goodsnameselect", {
          params: {
            pagenum: this.pagenum,
            pagesize: this.pagesize,
            query: this.query,
          },
        })
        .then((d) => {
            this.tableData = d.data.data;
           this.total=d.data.total;
          if (this.query=="") {
            this.getUserList();
          }
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
      if (this.query=="") {
        this.getUserList();
      }
      else{
        // alert("pagesize"+this.pagesize);
        this.getselect();
      }
    },
    //监听页码值改变的事件
    handleCurrentChange(newPage) {
      console.log(newPage + "pagenum");
      this.pagenum = newPage;
     
     if (this.query=="") {
        this.getUserList();
      }
      else{
        // alert("pagesize"+this.pagesize);
        this.getselect();
      }
    },
    //查询用户对话框
    async updateDialog(id) {
      this.updateVisible = true;
      console.log(id);
      this.$axios
        .get("/api/Food/goodidselect", {
          params: {
            goodid: id,
          },
        })
        .then((dt) => {
          if (dt.data != "") {
            this.updateform = dt.data[0];
            
          } else {
            this.$message.error("查询用户信息失败");
          }
        })
        .catch((l) => {
          console.log(l);
        });
    },
    //修改对话框的关闭按钮和事件
    updateDialogClosed() {
      this.$refs.updateformref.resetFields();
    
    },
    //修改用户并提交
    updateInfo() {
      this.$refs.updateformref.validate((valid) => {
        if (!valid) return;
        //发起数据请求
        this.$axios
          .post(
            "/api/Food/goodUpdate",
             this.updateform
          )
          .then((d) => {
            if (d.data == "修改成功") {
              this.updateVisible = false;
              this.getUserList();
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
    //根据id删除用户
    deleteUser(id) {
      console.log(id);
      this.$confirm("此操作将永久删除该用户, 是否继续?", "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning",
      })
        .then(async () => {
          this.$axios
            .get("/api/Food/gooddelete", {
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
              location.reload();
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
        });
    },
      //跳转到商品添加页面
      goAddpage(){
          this.$router.push('/goods/Add');
      },
      getselectss(){
         this.$axios
      .get("/api/Food/goods")
      .then((s) => {
        // this.total = s.data.length;
        this.query="";
        // this.tableData=s.data;
        this.getUserList();
      })
      .catch({});
      },
      //设置上传图片格式
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
      handleSuccess(response,file,fileList){
console.log("上传文件夹名"+file.name);
this.updateform.GoodImage=file.name;
      }
  },

  created() {
    // this.getselectss();
    this.getUserList();
    // this.getselect();
  },
};
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
.el-table {
  margin-top: 15px !important;
}
</style>