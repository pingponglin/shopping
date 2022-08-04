<template>
  <div>
       <!-- 面包屑导航区域 -->
    <el-breadcrumb separator-class="el-icon-arrow-right">
      <el-breadcrumb-item :to="{ path: '/shou' }">首页</el-breadcrumb-item>
      <el-breadcrumb-item>商品管理</el-breadcrumb-item>
      <el-breadcrumb-item>商品口味</el-breadcrumb-item>
    </el-breadcrumb>
    <!-- 卡片 -->
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
        <el-col :span="5">
          <el-button
                type="primary"
                @click="addDialog"
              >添加口味</el-button>
              <el-button type="primary" @click="goodkoweiss">刷新</el-button>
        </el-col>
      </el-row>
         <!-- <el-button
                type="primary"
                @click="addDialog"
              >添加口味</el-button> -->
        <el-table :data="tableData" border stripe style="width: 100%">
        <el-table-column prop="Goodkoweiid" label="编号" width="100">
        </el-table-column>
        <el-table-column prop="Goodkoweiname" label="口味名称" width="590">
        </el-table-column>
        <el-table-column prop="Good.GoodName" label="商品" width="330">
        </el-table-column>
        <el-table-column label="操作" width="234">
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
                @click="updateDialog(tableData.row.Goodkoweiid)"
              ></el-button>
            </el-tooltip>

            <!-- 删除用户 -->
            <el-button
              type="danger"
              icon="el-icon-delete"
              size="mini"
              @click="deleteUser(tableData.row.Goodkoweiid)"
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
          label="口味名称一"
          style="position: relative; left: 0px; margin: 33px auto"
          prop="Goodkoweiname"
        >
          <el-input v-model="updateform.Goodkoweiname"></el-input>
        </el-form-item>
        <el-form-item
          label="商品名称"
          style="position: relative; top: 0px; left: 0px"
          prop="Goodid"
        >
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
    <!-- 添加商品口味的对话框 -->
    <!-- @close关闭 -->
    <el-dialog
      title="添加口味"
      :visible.sync="ADDVisible"
      width="50%"
    >
      <!-- :rules="updateformRules" ref="updateformRel" -->
      <el-form :model="ADDform" :rules="ADDformRules" ref="ADDformref" label-width="100px" class="demo-ruleForm">
     <!-- <el-form
        :model="ADDform"
        label-width="100px"
        class="demo-ruleForm"
        :rules="ADDformRules"
        ref="ADDformref"
        style="height: 100%; width: 100%"
      > -->
        <el-form-item
          label="口味名称一"
          style="position: relative; left: 0px; margin: 33px auto"
          prop="Goodkoweiname"
        >
          <el-input v-model="ADDform.Goodkoweiname"></el-input>
        </el-form-item>
        <el-form-item
          label="商品名称"
          style="position: relative; top: 0px; left: 0px"
          prop="Goodid"
        >
          <!-- <el-input v-model="updateform.Good.Goodname"></el-input> -->
          <el-select v-model="ADDform.Goodid" placeholder="请选择">
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
        <el-button @click="ADDVisible = false">取 消</el-button>
        <el-button type="primary" @click="ADDInfo('ADDformref')">确 定</el-button>
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
      query:"",
       //控制修改对话框的显示与隐藏
      updateVisible: false,
      //控制添加对话框隐藏
      ADDVisible:false,
      //查询到的商品信息对象
      updateform: {
        // Goodname:""
        
      },
      //修改表单的验证规则
      updateformRules: {
        
      },
      //接收所有商品
      Good:[]
      ,
      //接受添加口味
      ADDform:{
        Goodkoweiname:"",
        Goodid:"",
      },
      //表单的验证规则
      ADDformRules:{
        Goodkoweiname: [
          { required: true, message: "请输入口味名称", trigger: "blur" }
        ],
        Goodid: [
          { required: true, message: "请输入商品", trigger: "change" }
        ]
      }
    }
}
,
methods:{
    async goodkoweiList() {
      this.$axios
        .get("/api/Food/goodkoweify", {
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
     //查询
    async getselect() {
      this.$axios
        .get("/api/Food/goodkoweiselect", {
          params: {
            pagenum: this.pagenum,
            pagesize: this.pagesize,
            query: this.query,
          },
        })
        .then((d) => {
          console.log(d)
          this.tableData = d.data.data;
          this.total=d.data.total;
          console.log(d.data);
          if (this.query=="") {
            this.goodkoweiList();
          }
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
        this.goodkoweiList();
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
        this.goodkoweiList();
      }
      else{
        // alert("pagesize"+this.pagesize);
        this.getselect();
      }
    },
    //添加对话框
    async addDialog(){
this.ADDVisible = true;
    
    },
    //添加口味并提交
    ADDInfo(formName){
this.$refs[formName].validate((valid) =>{
   if (valid) {
           this.$axios.post('/api/Food/goodkoweiADD',this.ADDform).then(d=>{
              if (d.data == "添加成功") {
              this.ADDVisible = false;
              this.goodkoweiList();
              console.log(d.data);
              this.ADDform={
        Goodkoweiname:"",
        Goodid:"",
      };
      this.goodkoweiss();
              return this.$message.success("添加口味信息成功!");
            } 
            else {
              return this.$message.error("添加口味信息失败!");
            }
           }).catch(l=>{console.log(l)})
          } else {
            console.log('error submit!!');
            return false;
          }
})
},
    //修改口味对话框
    async updateDialog(id) {
      this.updateVisible = true;
      console.log(id);
      this.$axios
        .get("/api/Food/goodkoweisid", {
          params: {
            goodkoweiid: id,
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
            "/api/Food/goodkoweiUpdate",
             this.updateform
          )
          .then((d) => {
            if (d.data == "修改成功") {
              this.updateVisible = false;
              this.goodkoweiList();
              
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
    deleteUser(id) {
      console.log(id);
      this.$confirm("此操作将永久删除该用户, 是否继续?", "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning",
      })
        .then(async () => {
          this.$axios
            .get("/api/Food/goodkoweidelete", {
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
                this.goodkoweiList();
                this.goodkoweiss();
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
    goodlist(){
      this.$axios
      .get("/api/Food/goods")
      .then((s) => {
        this.Good = s.data;
        
        // this.tableData=s.data;
      })
      .catch({});
    },
     goodkoweiss(){
      this.$axios
      .get("/api/Food/goodkoweis")
      .then(s => {
        this.total = s.data.length;
        // this.tableData=s.data;
        this.query="";
        this.goodkoweiList();
        console.log("total"+this.total);
      })
      .catch({});
    }
},
created() {
   this.goodkoweiss();
    
    this.goodkoweiList();
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