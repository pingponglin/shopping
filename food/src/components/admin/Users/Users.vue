<template>
  <div>
      <el-breadcrumb separator-class="el-icon-arrow-right">
  <el-breadcrumb-item :to="{ path: '/shou' }">首页</el-breadcrumb-item>
  <el-breadcrumb-item>用户管理</el-breadcrumb-item>
  <el-breadcrumb-item>用户列表</el-breadcrumb-item>
</el-breadcrumb>
      <!-- 卡片区域 -->
      <el-card>
    <!-- 搜索与添加区域 -->
  <el-row :gutter="20">
  <el-col :span="8">
         <el-input placeholder="请输入内容" v-model="query">
    <el-button slot="append" icon="el-icon-search" @click="getselect"></el-button>
    
  </el-input>
  </el-col>
  <el-col :span="4">
    <el-button type="primary" @click="getselectss">刷新</el-button>
  </el-col>
</el-row>
<!-- 用户列表区域 -->
   <el-table
    :data="tableData"
    border stripe
    style="width: 100%">
     <el-table-column
      prop="Userxixid"
      label="编号"
      width="250">
    </el-table-column>
    <el-table-column
      prop="Userxixname"
      label="姓名"
      width="250">
    </el-table-column>
    <el-table-column
      prop="Userxixphone"
      label="电话"
      width="250">
    </el-table-column>
    <el-table-column
      prop="Userxixemail"
      label="邮箱"
      width="250">
    </el-table-column>
    <el-table-column
      label="操作"
      width="254">
      <!-- 编辑用户 -->
          <template slot-scope="tableData">
                <el-tooltip effect="dark" content="编辑" placement="top" :enterable="false">
    <el-button
              type="primary"
              icon="el-icon-edit"
              size="mini" @click="updateDialog(tableData.row.Userxixid)"
            ></el-button>
    </el-tooltip>
        
            <!-- 删除用户 -->
            <el-button
              type="danger"
              icon="el-icon-delete"
              size="mini" @click="deleteUser(tableData.row.Userxixid)"
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
      :total="total">
    </el-pagination>
</el-card>
<!-- 修改用户的对话框 -->
<!-- @close关闭 -->
<el-dialog
  title="修改用户"
  :visible.sync="updateVisible"
  width="50%" @close="updateDialogClosed">
  <!-- :rules="updateformRules" ref="updateformRel" -->
  <el-form :model="updateform" label-width="70px" class="demo-ruleForm" :rules="updateformRules" ref="updateformref">
  <el-form-item label="用户名" style="position: relative;
    top: 0px;left: 0px;" prop="Userxixname">
    <el-input v-model="updateform.Userxixname" disabled></el-input>
  </el-form-item>
  <el-form-item label="电话" style="position: relative;
    top: 0px;left: 0px;" prop="Userxixphone">
    <el-input v-model="updateform.Userxixphone"></el-input>
  </el-form-item>
  <el-form-item label="邮箱" style="position: relative;
    top: 0px;left: 0px;" prop="Userxixemail">
    <el-input v-model="updateform.Userxixemail"></el-input>
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
    // 自定义邮箱校验规则
    var checkEmail = (rule, value, cb) => {
      const regEail = /^[A-Za-z\d]+([-_.][A-Za-z\d]+)*@([A-Za-z\d]+[-.])+[A-Za-z\d]{2,4}$/;
      if (regEail.test(value)) {
        return cb();
      }
      cb(new Error("请输入合法的邮箱"));
    };
    // 自定义手机号校验规则
    var checkMobile = (rule, value, cb) => {
      const regMobile = /^[1][3,4,5,7,8][0-9]{9}$/;
      if (regMobile.test(value)) {
        return cb();
      }
      cb(new Error("请输入合法的手机号"));
    };
    return {
      //获取用户的数据
      tableData: [],
      //当前的页数
      pagenum: 1,
      //当前每页的数据
      pagesize: 2,
      //获取总共的页数
      total: 0,
      //获取搜索的内容
      query: "",
      //控制修改对话框的显示与隐藏
      updateVisible: false,
      //查询到的用户信息对象
      updateform: {
      },
      //修改表单的验证规则
      updateformRules:{ 
        Userxixphone:[ 
          { required: true, message: '请输入用户手机号', 
        trigger: 'blur' },
        {validator:checkMobile,trigger:'blur'}
        ],
        Userxixemail:[ 
          { required: true, message: '请输入用户邮箱', 
        trigger: 'blur' },
        {validator:checkEmail,trigger:'blur'}
        ]
      }
    };
  },
  methods: {
    async getUserList() {
      this.$axios
        .get("/api/Food/foodUsersiddS", {
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
        .get("/api/Food/foodUsersnameselect", {
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
    //修改用户对话框
    async updateDialog(id) {
      this.updateVisible = true;
      console.log(id);
      this.$axios
        .get("/api/Food/foodUsersidselect", {
          params: {
            Userxixid: id,
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
    updateDialogClosed(){
      this.$refs.updateformref.resetFields();
    },
    //修改用户并提交
    updateInfo(){
      this.$refs.updateformref.validate(valid=>{
        if (!valid) return
          //发起数据请求
        this.$axios.post('/api/Food/foodUsersUpdate',this.$qstring.stringify({
          Userxixphone:this.updateform.Userxixphone,
          Userxixemail:this.updateform.Userxixemail,
          Userxixname:this.updateform.Userxixname
        })).then(d=>{
          if (d.data=="修改成功") {
            this.updateVisible=false;
            this.getUserList();console.log(d.data);
            return this.$message.success('更新用户信息成功!');
            
          }
          else{
            return this.$message.error('更新用户信息失败!')
          }
          
        })
        console.log(valid)
        });
    },
    //根据id删除用户
      deleteUser(id){
        console.log(id)
        this.$confirm('此操作将永久删除该用户, 是否继续?', '提示', {
          confirmButtonText: '确定',
          cancelButtonText: '取消',
          type: 'warning'
        }).then(async()=>{
          this.$axios.get('/api/Food/foodUsersidDelete',{
            params:{
              id:id
            }
          }).then(d=>{
            if (d.data=="删除成功") {
               this.$message({
              type: "success",
              message: "删除成功!"
            });
            // this.getUserList();
            location.reload();
            }
            else{
              this.$message({
              type: "success",
              message: "删除失败!"
            });
            }
          }).catch(l=>{console.log(l)})
        })
        .catch(() => {
          this.$message({
            type: "info",
            message: "已取消删除"
          });
        });
      },
      //查询所有用户
      getselectss(){
 this.$axios
      .get("/api/Food/foodUsers")
      .then((s) => {
        this.total = s.data.length;
        this.query="";this.getUserList();
        // this.tableData=s.data;
      })
      .catch({});
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
form label {
  position: absolute !important;
  display: block;
  width: 40px;
  height: 40px;
  line-height: 40px;
  background: #fff;
  text-align: center;
  /* top: 1px; */
  /* left: 1px; */
}
</style>