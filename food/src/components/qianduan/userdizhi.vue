<template>
  <div>
    <div class="am-cf am-padding">
              <div class="am-fl am-cf">
                <strong class="am-text-danger am-text-lg" style="font-size: 18px;color:black">地址管理</strong> /
                <small>Address&nbsp;list</small>
              </div>
            </div>
            <hr style="position: relative;
    bottom: 37px;" />
    <div class="tab" style="position: relative;
    bottom: 55px;">
      <!--标题 -->
    <!-- 用户列表区域 -->
    <el-button type="primary" size="mini" @click="addressadd">添加地址</el-button>
    <el-table
      :data="tableData"
      border
      stripe
      style="width: 99%; margin: 0 auto"
      :row-class-name="tableRowClassName"
    >
      <el-table-column prop="Addressname" label="收货人" width="100">
      </el-table-column>
      <el-table-column prop="Addresssuozaidiqu" label="所在地区" width="190">
      </el-table-column>
      <el-table-column prop="Addressxiangxidiqu" label="详细地址" width="190">
      </el-table-column>
      <el-table-column prop="Addressyoubian" label="邮编" width="100">
      </el-table-column>
      <el-table-column prop="Addressphone" label="手机号" width="150">
      </el-table-column>
      <el-table-column fixed="right" label="操作" width="180">
        <!-- 编辑用户 -->
        <template slot-scope="tableData">
          <el-button type="primary" size="mini" @click="addressupdate(tableData.row.Addressid)">修改</el-button>
          <!-- 删除用户 -->
          <el-button type="danger" size="mini" @click="addressdelete(tableData.row.Addressid)">删除</el-button>
        </template>
      </el-table-column>
      <el-table-column fixed="right" label="设置" width="110">
        <!-- 编辑用户 -->
        <template slot-scope="tableData">
          <el-button type="primary" v-show="shou(tableData.row.Addressstaus)" size="mini">默认地址</el-button>
          <!-- 删除用户 -->
          <el-button type="danger" size="mini" v-show="shou1(tableData.row.Addressstaus)" @click="mouren(tableData.row.Addressid)">设置默认</el-button>
        </template>
      </el-table-column>
    </el-table>
    </div>
    <!-- 修改收货地址 -->
    <el-dialog
      title="修改地址"
      :visible.sync="updateVisible"
      width="50%"
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
          label="收货人"
          style="position: relative; top: 0px; left: 0px"
          prop="Addressname"
        >
          <el-input v-model="updateform.Addressname"></el-input>
        </el-form-item>
         <el-form-item
          label="所在地区"
          style="position: relative; top: 0px; left: 0px"
          prop="Addresssuozaidiqu"
        >
          <el-input v-model="updateform.Addresssuozaidiqu"></el-input>
        </el-form-item>
        <el-form-item
          label="详细地址"
          style="position: relative; top: 0px; left: 0px"
          prop="Addressxiangxidiqu"
        >
          <el-input v-model="updateform.Addressxiangxidiqu"></el-input>
        </el-form-item>
        <el-form-item
          label="邮编"
          style="position: relative; top: 0px; left: 0px"
          prop="Addressyoubian"
        >
          <el-input v-model="updateform.Addressyoubian"></el-input>
        </el-form-item>
         <el-form-item
          label="手机号"
          style="position: relative; top: 0px; left: 0px"
          prop="Addressphone"
        >
          <el-input v-model="updateform.Addressphone"></el-input>
        </el-form-item>
      </el-form>
      <span slot="footer" class="dialog-footer">
        <el-button @click="updateVisible = false">取 消</el-button>
        <el-button type="primary" @click="updateInfo">确 定</el-button>
      </span>
    </el-dialog>
     <!-- 添加收货地址 -->
    <el-dialog
      title="添加地址"
      :visible.sync="addVisible"
      width="50%" @close="addDialogClosed"
    >
      <!-- :rules="updateformRules" ref="updateformRel" -->
      <el-form
        :model="addform"
        label-width="70px"
        class="demo-ruleForm"
        :rules="addformRules"
        ref="updateformref"
      >
        <el-form-item
          label="收货人"
          style="position: relative; top: 0px; left: 0px"
          prop="Addressname"
        >
          <el-input v-model="addform.Addressname" placeholder="请输入收货人"></el-input>
        </el-form-item>
         <el-form-item
          label="所在地区"
          style="position: relative; top: 0px; left: 0px"
          prop="Addresssuozaidiqu"
        >
          <el-input v-model="addform.Addresssuozaidiqu" placeholder="请选择省/市/区/街道"></el-input>
        </el-form-item>
        <el-form-item
          label="详细地址"
          style="position: relative; top: 0px; left: 0px"
          prop="Addressxiangxidiqu"
        >
          <el-input v-model="addform.Addressxiangxidiqu" placeholder="请输入详细地址详细，如道路、门牌号、小区、楼栋号】单元等信息"></el-input>
        </el-form-item>
        <el-form-item
          label="邮编"
          style="position: relative; top: 0px; left: 0px"
          prop="Addressyoubian"
        >
          <el-input v-model="addform.Addressyoubian" placeholder="请输入邮编"></el-input>
        </el-form-item>
         <el-form-item
          label="手机号"
          style="position: relative; top: 0px; left: 0px"
          prop="Addressphone"
        >
          <el-input v-model="addform.Addressphone" placeholder="请输入电话号码"></el-input>
        </el-form-item>
      </el-form>
      <span slot="footer" class="dialog-footer">
        <el-button @click="addVisible = false">取 消</el-button>
        <el-button type="primary" @click="addtianj">确 定</el-button>
      </span>
    </el-dialog>
  </div>
</template>

<script>
var checkEmail = (rule, value, cb) => {
  const regEail =
    /^[A-Za-z\d]+([-_.][A-Za-z\d]+)*@([A-Za-z\d]+[-.])+[A-Za-z\d]{2,4}$/;
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
export default {
  data() {
    return {
      tableData: [],
      //接收用户的id
      userid: "",
      //接收用户点击设置默认地址获取点击那行的索引
      shouying:""
      ,
      //控制修改是否显示和隐藏
      updateVisible:false,
      updateform:{},
      updateformRules: {
		Addressname: [
          { required: true, message: "请输入收货人", trigger: "blur" }
        ],
        Addresssuozaidiqu: [
          { required: true, message: "请输入地区", trigger: "blur" }
        ],
		Addressxiangxidiqu: [
          { required: true, message: "请输入详细地址", trigger: "blur" }
        ],
        Addressyoubian: [
          { required: true, message: "请输入邮编", trigger: "blur" }
        ],
        Addressphone: [
          { required: true, message: "请输入用户手机号", trigger: "blur" },
          { validator: checkMobile, trigger: "blur" },
        ]
      },
      //控制修改是否显示和隐藏
      addVisible:false,
      addform:{},
      addformRules: {
		Addressname: [
          { required: true, message: "请输入收货人", trigger: "blur" }
        ],
        Addresssuozaidiqu: [
          { required: true, message: "请输入地区", trigger: "blur" }
        ],
		Addressxiangxidiqu: [
          { required: true, message: "请输入详细地址", trigger: "blur" }
        ],
        Addressyoubian: [
          { required: true, message: "请输入邮编", trigger: "blur" }
        ],
        Addressphone: [
          { required: true, message: "请输入用户手机号", trigger: "blur" },
          { validator: checkMobile, trigger: "blur" },
        ]
      },
    };
  },
  methods: {
    //根据Id查询所有收货地址信息
    getaddress() {
      this.$axios.get("/api/Food/addresses?id=" + this.userid).then((s) => {
        if (s.data != "") {
          this.tableData = s.data;
          // data.sort((a, b) => a.english.charCodeAt(0) - b.english.charCodeAt(0)); //a~z 排序   
           this.tableData.sort((a, b) => b.Addressstaus.charCodeAt(0) - a.Addressstaus.charCodeAt(0)); //z-a 排序    
      console.log("sssssssssss");
    console.log(this.tableData);

        }
      });
    },
    //获取每一行的索引
    tableRowClassName({ row, rowIndex }) {
      //把每一行的索引放进row
      row.index = rowIndex;
      this.shouying=row.index;
    },
    //点击设置默认地址
    mouren(id) {
      this.$axios.get("/api/Food/addressesid?id=" + id).then((s) => {
        if (s.data == "修改成功") {
          this.tableData=s.data;
        this.$message({
          message: '设置默认地址成功',
          type: 'success'
        });
        this.getaddress();
        //点击获取索引
      const i = this.shouying;
      const addressList = this.tableData;
      addressList.forEach((item, index) => {
        item.isDefault = index == i;
      });
      addressList.splice(0, 0, ...addressList.splice(i, 1));
        }
      });
      
    },
    //判断Addressstaus为true就显示，false就隐藏
    shou(sender){
     if (sender=="true") {
       return true;
     }
     else{
       return false;
     }
    },
     //判断Addressstaus为false就显示，true就隐藏
    shou1(sender){
     if (sender=="false") {
       return true;
     }
     else{
       return false;
     }
    },
    //根据点击修改的id查询所有的收货信息
    addressupdate(id){
this.updateVisible=true;
this.$axios.get("/api/Food/addressesids?id=" + id).then((s) => {
        if (s.data != "") {
          this.updateform = s.data[0];
        }
      });
    },
    //提交修改
    updateInfo(){
	this.$refs.updateformref.validate(valid=>{
        if (!valid) return
          //发起数据请求
        this.$axios.post('/api/Food/addressupdate',this.updateform
        ).then(d=>{
          if (d.data=="修改成功") {
            this.getaddress();
            this.updateVisible=false;
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
    addressdelete(id) {
      console.log(id);
      this.$confirm("此操作将永久删除该用户, 是否继续?", "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning",
      })
        .then(async () => {
          this.$axios
            .get("/api/Food/addressdelete?id="+id)
            .then((d) => {
              if (d.data == "删除成功") {
                this.$message({
                  type: "success",
                  message: "删除成功!",
                });
              this.getaddress();
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
    //添加
    addressadd(){
      this.addVisible=true;
    },
    //添加数据
addtianj(){
  this.addform.Userxixids=this.userid;
  this.$refs.updateformref.validate((valid) =>{
   if (valid) {
     this.$axios.post('/api/Food/addressADD',this.addform).then(d=>{
  if (d.data=="添加成功") {
   this.addVisible=false;
   this.getaddress();
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
addDialogClosed(){
  this.$refs.updateformref.resetFields();
}
  },
  created() {
    this.userid = this.$route.query.userids;
    this.getaddress();
  },
};
</script>

<style scoped>
.tab {
  margin-top: 7px !important;
}
/* CSS Document */
[class*="am-u-"] {
  padding-left: 0px;
  padding-right: 0px;
}
.am-thumbnails > li {
  padding: 0 0.5rem 0 0.5rem;
}
.am-form textarea,
.am-form select,
.am-form textarea,
.am-form input[type="text"],
.am-form input[type="password"],
.am-form input[type="datetime"],
.am-form input[type="datetime-local"],
.am-form input[type="date"],
.am-form input[type="month"],
.am-form input[type="time"],
.am-form input[type="week"],
.am-form input[type="tel"],
.am-form input[type="email"],
.am-form input[type="url"],
.am-form input[type="search"],
.am-form input[type="tel"],
.am-form input[type="color"],
.am-form-field,
.am-btn {
  font-size: 14px;
}
.user-address {
  font-size: 12px;
}
.am-thumbnails {
  margin: 0px 0px;
  margin-bottom: 50px;
}
.user-address li.user-addresslist {
  float: none;
  min-height: 80px;
  position: relative;
  border-bottom: 1px solid #eee;
  padding: 15px 10px;
}
.new-tit {
  padding-bottom: 7px;
  font-size: 14px;
  position: relative;
}
.new-txt {
  padding-left: 15px;
  background: url(../../assets/images/addicon1.png) 1px 2px no-repeat;
  color: #6e6e6e;
}
.new-txt-rd2 {
  padding-left: 20px;
  color: #a40000;
}

/*地址操作*/
.am-padding form {
  margin: 0px 10px;
}
.new-mu_l2a {
  padding: 6px 15px 8px;
  display: block;
  background: url(../../assets/images/addicon.png) 1px 9px no-repeat;
}
.new-mu_l2cw {
  font-size: 12px;
  color: #6e6e6e;
}
.new-addr-btn {
  color: #282828;
  text-align: right;
}
.new-addr-bar {
  padding: 0px 10px;
  vertical-align: top;
}
.new-addr-btn i {
  color: #d4d4d4;
  font-size: 14px;
  padding-right: 10px;
}
a.new-abtn-type {
  display: block;
  padding: 8px;
  overflow: hidden;
  border-radius: 2px;
  background-color: #c00;
  font-size: 14px;
  color: #fff;
  text-align: center;
  position: fixed;
  bottom: 0px;
  width: 100%;
  cursor: pointer;
}

.new-option-r {
  position: absolute;
  z-index: 999;
  cursor: pointer;
  bottom: 15px;
}
.new-option-r i {
  color: #d4d4d4;
  padding-right: 5px;
  font-size: 14px;
}
.user-address li.user-addresslist.defaultAddr .new-option-r i {
  color: #ee3495;
}

/*地址增加*/
.am-modal {
  background: #fff;
  width: 100%;
  margin: 0px 0px !important;
  left: 0;
  top: 0;
  height: 100%;
}
.am-form-content.address select {
  float: left;
  width: 32%;
  margin-left: 1%;
}
.am-selected {
  width: 32.3%;
  max-width: 200px;
  float: left;
  margin-left: 1%;
}
.address li {
  font-size: 12px;
}
.am-close {
  width: auto;
  line-height: 1.2;
  opacity: 0.8;
  text-shadow: none;
  color: #fff !important ;
}
.footer {
  display: none;
}
@media only screen and (min-width: 640px) {
  .new-tit {
    border: none;
  }
  a.new-abtn-type {
    display: none;
  }
  .user-address li {
    width: 100%;
  }

  .new-txt-rd2 {
    background: url(../../assets/images/addicon2.png) 1px 10px no-repeat;
    padding-left: 15px;
    padding-top: 8px;
  }
  .am-form-content {
    margin-left: 105px;
  }
  .new-option-r {
    position: absolute;
    top: 7px;
    right: 10px;
    bottom: auto;
  }
  .footer {
    display: block;
  }

  /*地址增加*/
}

@media only screen and (min-width: 1025px) {
  .new-mu_l2cw {
    height: 55px;
  }
  .new-addr-btn {
    padding-right: 12px;
    padding-bottom: 10px;
  }
  .new-tit {
    padding: 8px 12px 0px 0px;
  }
  .user-address li.user-addresslist {
    overflow: hidden;
    border: none;
    display: block;
    width: 255px;
    height: 150px;
    float: left;
    background: url(../../assets/images/peraddbg.png) no-repeat scroll 0% 0%;
    margin-right: 10px;
  }
  .user-address li.user-addresslist.defaultAddr {
    background: url(../../assets/images/peraddressbg.png) no-repeat scroll 0% 0%;
  }
  .user-address li {
    width: 255px;
    margin-right: 20px;
  }

  .new-option-r {
    position: absolute;
    top: 0px;
    right: 3px;
    padding: 0px 5px;
    border-radius: 0 0 5px 5px;
    color: #fff;
  }
  .new-option-r i {
    display: none;
  }
  /*一些操作*/
  .user-addresslist .new-option-r {
    position: absolute;
    top: -18px;
    background: #f974ba;
  }
  .user-addresslist.defaultAddr .new-option-r {
    top: 0px;
    background: #ee3495;
  }
  .user-addresslist .new-addr-btn {
    display: none;
  }
  .user-addresslist.defaultAddr .new-addr-btn,
  .user-addresslist:hover .new-addr-btn,
  .user-addresslist.active .new-addr-btn {
    display: block;
  }
  .user-addresslist:hover .new-option-r,
  .user-addresslist.active .new-option-r {
    position: absolute;
    top: 0px;
  }
}
</style>