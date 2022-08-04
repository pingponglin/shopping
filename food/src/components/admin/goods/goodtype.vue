<template>
  <div>
       <!-- 面包屑导航区域 -->
    <el-breadcrumb separator-class="el-icon-arrow-right">
      <el-breadcrumb-item :to="{ path: '/shou' }">首页</el-breadcrumb-item>
      <el-breadcrumb-item>商品管理</el-breadcrumb-item>
      <el-breadcrumb-item>商品分类</el-breadcrumb-item>
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
              >添加商品分类</el-button>
              <el-button type="primary" @click="goodtypetwo">刷新</el-button>
        </el-col>
      </el-row>
        <el-table :data="tableData" border stripe style="width: 100%">
        <el-table-column prop="Goodtypetwoid" label="编号" width="190">
        </el-table-column>
        <el-table-column prop="Goodtypeone.Goodtypeonename" label="一级分类" width="250">
        </el-table-column>
        <el-table-column prop="Goodtypetwoname" label="二级分类" width="250">
        </el-table-column>
        <el-table-column prop="Good.GoodName" label="商品名称" width="360">
        </el-table-column>
        <el-table-column label="操作" width="204">
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
                @click="updateDialog(tableData.row.Goodtypetwoid)"
              ></el-button>
            </el-tooltip>

            <!-- 删除用户 -->
            <el-button
              type="danger"
              icon="el-icon-delete"
              size="mini"
              @click="deleteUser(tableData.row.Goodtypetwoid,tableData.row.Goodtypeoneid)"
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
          label="一级分类"
          style="position: relative; top: 0px; left: 0px"
          prop="Goodtypeoneid"
        >
          <el-input v-model="updateform.Goodtypeone.Goodtypeonename"></el-input>
        </el-form-item>
        <el-form-item
          label="二级分类"
          style="position: relative; top: 0px; left: 0px"
          prop="Goodtypetwoid"
        >
          <el-input v-model="updateform.Goodtypetwoname"></el-input>
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
    <!-- 添加商品口味的对话框 -->
    <!-- @close关闭 -->
   
    <!-- 添加二级分类 -->
    <el-dialog
      title="添加二级分类"
      :visible.sync="ADDtwo"
      width="50%"
    >
      <!-- :rules="updateformRules" ref="updateformRel" -->
      <el-form :model="ADDformtwo" :rules="ADDformRulestwo" ref="ADDformreftwo" label-width="100px" class="demo-ruleForm">
        <el-form-item
          label="商品一级分类"
          style="position: relative; left: 0px; margin: 33px auto"
          prop="Goodtypeonename"
        >
    <el-select v-model="ADDformtwo.Goodtypeoneid" placeholder="请选择">
    <el-option
      v-for="item in Goodtypeones"
      :key="item.Goodtypeoneid"
      :label="item.Goodtypeonename"
      :value="item.Goodtypeoneid">
    </el-option>
  </el-select>
        </el-form-item>
        <el-form-item
          label="商品二级分类"
          style="position: relative; top: 0px; left: 0px"
          prop="Goodtypetwoname"
        >
          <el-input v-model="ADDformtwo.Goodtypetwoname"></el-input>
        </el-form-item>
        <el-form-item
          label="商品名称"
          style="position: relative; top: 0px; left: 0px"
          prop="Goodid"
        >
          <!-- <el-input v-model="updateform.Good.Goodname"></el-input> -->
          <el-select v-model="ADDformtwo.Goodid" placeholder="请选择">
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
        <el-button @click="ADDtwo = false">取 消</el-button>
        <el-button type="primary" @click="ADDInfotwo">确 定</el-button>
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
      //添加一级对话框
      ADDVisible:false,
      //添加二级对话框
      ADDtwo:false
      ,
      //查询到的商品信息对象
      updateform: {
        Goodtypeone:{Goodtypeoneid:"",Goodtypeonename:""}
        
      },
      //修改表单的验证规则
      updateformRules: {
        
      },
      //接收所有商品
      Good:[],
      //接受商品一级分类
      Goodtypeones:[],
      //接受商品二级分类
      Goodtypetwos:[],
      //接受添加口味
      ADDform:{
        Goodtypeonename:"",
        Goodtypetwoname:"",

      },
      //表单的验证规则
      ADDformRules:{
        Goodtypeonename: [
          { required: true, message: "请输入一级分类", trigger: "blur" }
        ]
      },
      //接收二级分类
      ADDformtwo:{},
      //二级分类验证规则
      ADDformRulestwo:{
        Goodtypeoneid: [
          { required: true, message: "请输入一级分类", trigger: "blur" }
        ],
        Goodtypetwoname: [
          { required: true, message: "请输入二级分类", trigger: "blur" }
        ],
        Goodid: [
          { required: true, message: "请输入商品", trigger: "change" }
        ]
      }
      ,
      //根据名称查询到的一级分类的id
      oneid:""
    }
}
,
methods:{
  //分页查询
    async goodtypeList() {
      this.$axios
        .get("/api/Food/goodtypetwofy", {
          params: {
            pagenum: this.pagenum,
            pagesize: this.pagesize,
          },
        })
        .then((d) => {
          this.tableData = d.data.data;
           this.total=d.data.total;
          console.log(d.data);
        })
        .catch((l) => {
          console.log(l);
        });
    },
     //查询
    async getselect() {
      this.$axios
        .get("/api/Food/goodsnametwoselect", {
          params: {
            pagenum: this.pagenum,
            pagesize: this.pagesize,
            query: this.query,
          },
        })
        .then((d) => {
          this.tableData = d.data.data;
           this.total=d.data.total;
          console.log(d.data);
          if (this.query=="") {
            this.goodtypeList();
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
        this.goodtypeList();
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
        this.goodtypeList();
      }
      else{
        
        this.getselect();
      }
    },
    //添加对话框
    async addDialog(){
this.ADDtwo=true;
    },
//添加二级分类并提交
 ADDInfotwo(){
this.$refs.ADDformreftwo.validate((valid) =>{
   if (valid) {
             this.$axios.post('/api/Food/goodtypetwoADD',this.ADDformtwo).then(d=>{
              if (d.data == "添加成功") {
              this.ADDtwo = false;
             
              console.log(d.data);
              this.goodtypeList();
              this.ADDformtwo.Goodtypeoneid="";
               this.ADDformtwo.Goodid="";
                this.ADDformtwo.Goodtypetwoname="";
              return this.$message.success("添加二级分类成功!"); 
              
            } 
            else {
              return this.$message.error("添加二级分类失败!");
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
        .get("/api/Food/goodtypetwoselectid", {
          params: {
            goodtypetwoid: id,
          },
        })
        .then((dt) => {
          if (dt.data != "") {
            this.updateform = dt.data[0];
            // this.updateform.Goodtypeonename=dt.data[0].Goodtypeone.Goodtypeonename;
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
            "/api/Food/goodtypeUpdate",
             this.updateform
          )
          .then((d) => {
            if (d.data == "修改成功") {
              this.updateVisible = false;
              this.goodtypeList();
              
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
    //根据id删除商品分类
    deleteUser(id,oneid) {
      console.log(id);
      console.log(oneid);
      this.$confirm("此操作将永久删除该用户, 是否继续?", "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning",
      })
        .then(async () => {
             this.$axios
            .get("/api/Food/goodtypetwodelete", {
              params: {
                ids: id,
              },
            })
            .then((d) => {
              if (d.data == "删除成功") {
                this.$message({
                  type: "success",
                  message: "删除成功!",
                });
                this.goodtypeList();
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
    }
    ,
    //查询所有商品
    goodlist(){
      this.$axios
      .get("/api/Food/goods")
      .then((s) => {
        this.Good = s.data;
        
        // this.tableData=s.data;
      })
      .catch({});
    },
    //查询所有二级分类类型
     goodtypeiss(){
      this.$axios
      .get("/api/Food/goodtypetwo")
      .then(s => {
        this.total = s.data.length;
        // this.tableData=s.data;
        // this.Goodtypetwos = s.data;
        console.log("total"+this.total);
      })
      .catch({});
    },
    //查询所有商品一级分类
    goodtypeone(){
        this.$axios
      .get("/api/Food/goodtypeone")
      .then((s) => {
        this.Goodtypeones= s.data;
        
        // this.tableData=s.data;
      })
      .catch({});
    }
    ,
    //点击刷新查询所有商品二级分类
    goodtypetwo(){
        this.$axios
      .get("/api/Food/goodtypetwo")
      .then((s) => {
        
        this.total=s.data.length;
        this.query=""; this.goodtypeList();
        // this.tableData=s.data;
      })
      .catch({});
    }
},
created() {
   this.goodtypeiss();
    this.goodtypeone();
    this.goodtypetwo;
    this.goodtypeList();
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