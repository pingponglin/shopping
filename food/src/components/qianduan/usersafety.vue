<template>
  <div>
    <div class="am-cf am-padding">
      <div class="am-fl am-cf">
        <strong class="am-text-danger am-text-lg" style="font-size: 18px;color:black">账户安全</strong> /
        <small>Set&nbsp;up&nbsp;Safety</small>
      </div>
    </div>
    <hr style="position: relative;
    bottom: 37px;" />

    <!--头像 -->
            <div
              class="user-infoPic"
              v-for="item in getuserlist"
              :key="item.Userxixid"
            >
              <div class="filePic">
                <input
                  type="file"
                  class="inputPic"
                  allowexts="gif,jpeg,jpg,png,bmp"
                  accept="image/*"
                />
                <img
                  class="am-circle am-img-thumbnail"
                  :src="'http://81.68.132.153:7070/img/' + item.Userxixnich"
                  alt="" style="border: none;"
                />
              </div>

              <p class="am-form-help">头像</p>

              <div class="info-m">
                <div>
                  <b
                    >用户名：<i>{{ item.Userxixname }}</i></b
                  >
                </div>
                <div class="u-safety">
                  <a href="safety.html">
                    账户安全
                    <span class="u-profile"
                      ><i class="bc_ee0000" style="width: 60px" width="0"
                        >100分</i
                      ></span
                    >
                  </a>
                </div>
              </div>
            </div>

    <div class="check">
      <ul>
        <li>
          <div style="margin: 0px auto;width: 971px;display: flex;">
              <img src="../../assets/images/yonghu.png" style="width:110px;" alt="">
              <p style="position: relative;
    top: 26px;"><span style="font-size: 17px;font-weight:bold;">登录密码</span><br><span>为保证您购物安全，建议您定期更改密码以保护账户安全。</span><el-button
                style="margin-left: 250px"
                type="primary" @click="wangjia"
                >修改</el-button
              ></p>
          </div>
        </li>
        <!-- <li>
         <div style="margin: 0px auto;width: 971px;display: flex;">
              <img src="../../assets/images/手机-4.png" style="width:110px;" alt="">
              <p style="position: relative;
    top: 26px;"><span style="font-size: 17px;font-weight:bold;">手机验证</span><br><span>您验证的手机：XXXXXXXXXX若已丢失或停用,请立即更换</span><el-button
                style="margin-left: 250px"
                type="primary"
                >换绑</el-button
              ></p>
          </div>
        </li> -->
      </ul>
    </div>
     <el-dialog title="找回密码" :visible.sync="dialogVisible" width="30%">
      <el-form
        :model="ruleForms"
        :rules="rules"
        ref="ruleForms"
        label-width="100px"
        class="demo-ruleForm"
      >
        <el-form-item
          prop="xin"
          label="原密码:" 
          style="position: relative; top: 0px; left: 0px"
        >
          <el-input
            v-model="ruleForms.xin"
             type="password"
            prefix-icon="el-icon-user-solid"
            placeholder="请输入原密码"
          ></el-input>
        </el-form-item>
       <el-form-item
          prop="Usermima"
          label="新密码:"
          style="position: relative; top: 0px; left: 0px"
        >
          <el-input
           type="password"
            v-model="ruleForms.Usermima"
            prefix-icon="el-icon-user-solid"
            placeholder="请输入新密码"
          ></el-input>
        </el-form-item>
         <el-form-item
          prop="checkPass"
          label="新密码:"
          style="position: relative; top: 0px; left: 0px"
        >
          <el-input
            v-model="ruleForms.checkPass"
           prefix-icon="el-icon-user-solid"
            placeholder="请再次输入新密码"
          ></el-input>
        </el-form-item>
               <el-form-item>
                    <span class="dialog-footer">
        <el-button @click="dialogVisible = false">取 消</el-button>
        <el-button type="primary" @click="dengliu('ruleForms')">确 定</el-button>
      </span>
                    </el-form-item>
      </el-form> 
      
    </el-dialog>
  </div>
</template>

<script>
export default {
    data(){
       var validatePass = (rule, value, callback) => {
        if (value === '') {
          callback(new Error('请输入密码'));
        } else {
          if (this.ruleForms.checkPass !== '') {
            this.$refs.ruleForms.validateField('checkPass');
          }
          callback();
        }
      };
      var validatePass2 = (rule, value, callback) => {
        if (value === '') {
          callback(new Error('请再次输入密码'));
        } else if (value !== this.ruleForms.Usermima) {
          callback(new Error('两次输入密码不一致!'));
        } else {
          callback();
        }
      };
        return{
             show:true,   
           count:'',    
           timer:null ,
           sms:"",
            //接收用户的id
      userid: "",
      //接收用户所有的数据
      getuserlist: [],
       dialogVisible:false,
      ruleForms: {
        Userxixid:"",
        Usermima: "",
        xin: "",
        checkPass:""
      },
        rules: {
        // xin:[ { required: true, message: '请输入原密码', trigger: 'blur' }],
        Usermima: [{ validator: validatePass2, trigger: "blur" }],
        checkPass: [{ validator: validatePass, trigger: "blur" }]
      }
        }
    },
    methods:{
 getuser() {
      this.$axios
        .get("/api/Food/foodUsersid?pagenum=" + this.userid)
        .then((s) => {
          this.getuserlist = s.data;
          this.updateform = s.data[0];
          console.log(s.data);
        });
    },
    //验证码倒计时
    getCode(){
               const TIME_COUNT = 60;
               this.$axios.get('/api/Food/SendSMS?phone='+this.ruleForm.Userxixphone).then(s=>{
              console.log(s.data.sms);
              this.sms=s.data.sms;
              console.log(this.sms);
         });
                if (!this.timer) {
                this.count = TIME_COUNT;
                 this.show = false; 
                 this.timer = setInterval(() => {
                  if (this.count > 0 && this.count <= TIME_COUNT) { 
                   this.count--;  }
                    else {  
                    this.show = true;  
                    clearInterval(this.timer);  
                    this.timer = null;  } }, 
          1000) }} ,
           //忘记密码
    wangjia(){
     this.dialogVisible=true;
    },
    dengliu(){
  this.$axios.get('/api/Food/foodUseridname',{
          params: {
            id: this.userid,
            name: this.ruleForms.xin
          },
       }).then(s=>{
          console.log("dsad");
         console.log(s.data);
         if (s.data!="") {
           this.ruleForms.Userxixid=this.userid;
              this.$axios.post('/api/Food/foodUseridnamse',this.ruleForms).then(d=>{
                if (d.data=="修改成功") {
                   this.$message.success('你修改的密码为:'+s.data[0].Usermima);
                   this.dialogVisible=false;
                }
                else{
                  this.$message.error('密码错误');
                }
              });
         }
         else{
           this.$message.error('原密码错误');
         }
       });
    },
    //根据原密码和用户id查询密码
    yuan(){
         alert(this.ruleForms.xin);
    }
    },
    created(){
         this.userid = this.$route.query.userids;
    this.getuser();
    }
};
</script>

<style  scoped>
@charset "utf-8";
/* CSS Document */
[class*="am-u-"] {
  padding-left: 0;
  padding-right: 0;
  }
.user-infoPic {
  overflow: hidden;
  position: relative;
  margin: 0px 10px;
  padding: 0px 5px 0px 0px;
  border-bottom: 1px solid #e4eaee;
}
.filePic {
  position: relative;
  width: 60px;
  text-align: center;
  float: right;
}
.inputPic {
  cursor: pointer;
  opacity: 0;
  ilter: alpha(opacity=0);
  width: 100%;
  height: 100%;
  position: absolute;
  top: 0;
  left: 0;
  z-index: 9;
}
p.am-form-help {
  font-size: 14px;
  font-weight: 600;
  margin: 0px auto;
  position: absolute;
  top: 25px;
  color: #000000;
}
.am-selected-list {
  font-size: 14px;
}
.am-img-thumbnail {
  padding: 0px;
  margin: 2px;
}
.info-m {
  display: none;
}

/*修改信息*/
.info-main {
  max-width: 800px;
  padding: 0px 10px;
}
.am-form-group {
  margin: 10px 0px;
  border-bottom: 1px solid #e4eaee;
  height: 34px;
}
.am-form-horizontal .am-form-label {
  padding-top: 8px;
  text-align: left;
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
.birth-select,
.birth-select2 {
  float: left;
  margin-right: 5px;
  vertical-align: middle;
}
.birth-select select {
  float: left;
  width: 60px;
  background: none;
  border: none;
  padding-top: 9px;
}
.birth-select2 select {
  float: left;
  width: 40px;
  background: none;
  border: none;
  padding-top: 9px;
}

.birth button {
  border: none;
}
.birth .am-selected-icon::before {
  opacity: 0;
}
.user-info {
  width: 100%;
  max-width: 900px;
  overflow: hidden;
}
.user-safety {
  width: 100%;
  max-width: 900px;
  overflow: hidden;
}

/*按钮*/
.info-btn {
  text-align: center;
}
.fore3 .am-btn-secondary {
  color: #000;
  background-color: transparent;
  border: none;
}

/*地址*/
.am-form-content.address a,
.am-form-group.safety a {
  width: 80%;
  float: right;
  text-align: right;
  padding-right: 5px;
}
p.new-mu_l2cw {
  margin: 0px;
}
p.new-mu_l2cw span {
  height: 17px;
  line-height: 17px;
}

/*性别*/
.sex .am-ucheck-icons {
  top: 8px;
}
/*安全设置*/
.user-safety .check {
  max-width: 900px;
}
.user-safety .check li {
  overflow: hidden;
  margin: 5px 10px;
  padding: 8px 0px;
  border-bottom: 1px solid #e4eaee;
}
.user-safety .check .m-left {
  float: left;
}
.user-safety .check .fore1 {
  width: 80px;
  font-size: 14px;
  font-weight: 600;
  line-height: 21px;
  padding-top: 5px;
}
.user-safety .check .fore2 {
  display: none;
  text-align: left;
  font-size: 12px;
  line-height: 21px;
}
.user-safety .check .fore3 {
  text-align: center;
  font-size: 12px;
  float: right;
  line-height: 21px;
}
.am-btn {
  padding: 5px;
}
.user-safety .check i {
  margin-left: 10px;
}
.user-safety .fore3 .am-btn {
  width: 70px;
}

/*表单配置*/
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
.am-form input[type="color"] {
  background: none;
  border: none;
}
input::-webkit-input-placeholder {
  text-align: right;
}
input {
  text-align: right;
}
.am-form-label {
  font-size: 14px;
  font-weight: 600;
  width: auto;
}
.sex,
.birth {
  float: right;
  padding-right: 5px;
  margin-left: 0;
}

.am-form-content small {
  display: none;
}
.am-selected {
  width: auto;
}

@media only screen and (min-width: 640px) {
  .am-form-group.address,
  .am-form-group.safety,
  .am-form-help {
    display: none;
  }
  .sex,
  .birth {
    float: none;
    margin-left: 85px;
  }
  .am-radio-inline input[type="radio"] {
    margin-left: 0px;
  }
  input::-webkit-input-placeholder,
  input {
    text-align: left;
  }
  .info-main {
    margin: 0% 5%;
  }
  .user-infoPic,
  .am-form-group {
    border: none;
  }
  .am-form-group {
    margin: 20px 0px;
  }
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
  .birth-select select,
  .birth-select2 select {
    border: 1px solid #e4eaee;
  }
  input {
    text-align: left;
  }
  .am-form-group {
    height: 50px;
  }
  .am-form-horizontal .am-form-label {
    padding-top: 8px;
  }
  .am-form-content small {
    display: block;
    margin: 5px 5px;
    color: #ccc;
  }
  /*生日*/

  .birth-select select,
  .birth-select2 select {
    -webkit-appearance: none !important;
    -moz-appearance: none !important;
    -webkit-border-radius: 0;
    background: #ffffff
      url("data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZlcnNpb249IjEuMSIgeD0iMTJweCIgeT0iMHB4IiB3aWR0aD0iMjRweCIgaGVpZ2h0PSIzcHgiIHZpZXdCb3g9IjAgMCA2IDMiIGVuYWJsZS1iYWNrZ3JvdW5kPSJuZXcgMCAwIDYgMyIgeG1sOnNwYWNlPSJwcmVzZXJ2ZSI+PHBvbHlnb24gcG9pbnRzPSI1Ljk5MiwwIDIuOTkyLDMgLTAuMDA4LDAgIi8+PC9zdmc+")
      no-repeat 100% center;
  }

  .birth-select {
    width: 38%;
    margin-right: 0;
    position: relative;
    height: 32px;
    line-height: 32px;
  }
  .birth-select2 {
    width: 30%;
    margin-right: 0;
    margin-left: 1%;
    position: relative;
    height: 32px;
    line-height: 32px;
  }
  .birth-select select,
  .birth-select2 select {
    width: 90%;
  }
  .birth-select em,
  .birth-select2 em {
    position: absolute;
    right: 0px;
  }
  .birth-select .am-selected,
  .birth-select2 .am-selected {
    width: auto;
    position: absolute;
    left: 0px;
    right: 20px;
  }
  .birth button {
    border: 1px solid #e4eaee;
  }
  .birth .am-selected-icon::before {
    opacity: 1;
    margin: 5px 0px 5px -10px;
  }
  .birth .am-selected-status {
    padding-top: 3px;
  }
  /*头像、安全评分*/
  .user-infoPic {
    position: relative;
    margin: 20px 5% 50px;
    height: 130px;
    border-bottom: 1px solid #eee;
  }
  .filePic {
    width: 100px;
    float: left;
    margin-left: 15px;
    margin-top: 15px;
  }
  .info-m {
    display: block;
    float: left;
    overflow: hidden;
    line-height: 24px;
    position: absolute;
    left: 6%;
    top: 25px;
    margin-left: 120px;
  }
  .safeText {
    display: block;
    color: #fff;
    position: relative;
    text-align: left;
  }
  .progressBar {
    width: 190px;
    height: 8px;
    position: relative;
    overflow: hidden;
    border-radius: 5px;
    margin-top: 5px;
  }
  .progress {
    width: 190px;
    height: 8px;
    position: absolute;
    top: 0;
    background-color: #ffeb68;
    border-radius: 5px;
  }
  /*会员*/
  .vip {
    margin-top: 15px;
  }
  .vip span {
    display: block;
    width: 51px;
    height: 22px;
    float: left;
    margin-right: 5px;
  }
  .user-info {
    overflow: hidden;
    margin-bottom: 15px;
  }
  /*安全设置*/
  .user-safety .check li {
    padding: 15px 0px;
    position: relative;
    border: none;
  }
  .user-safety .check .fore2 {
    display: block;
  }
  .user-safety .check .fore1 {
    width: 100px;
    font-size: 16px;
  }
  /*小图标*/
  .user-safety .check i {
    left: 0;
    display: inline-block;
    vertical-align: middle;
    background-image: url("../../assets/images/sprite.png");
    width: 40px;
    height: 40px;
    position: absolute;
    margin-top: 5px;
  }
  .i-safety-lock {
    background-position: -90px -45px;
  }
  .i-safety-wallet {
    background-position: 0px -135px;
  }
  .i-safety-iphone {
    background-position: -45px 0px;
  }
  .i-safety-mail {
    background-position: 0px -90px;
  }
  .i-safety-idcard {
    background-position: -90px -90px;
  }
  .i-safety-security {
    background-position: -135px -45px;
  }

  .user-safety .check .m-left {
    margin-left: 70px;
  }
  .user-safety .check .fore3 {
    margin-top: 10px;
  }
  /*按钮*/
  .fore3 .am-btn-secondary {
    color: #fff;
    background-color: #3bb4f2;
    border: 1px solid #3bb4f2;
  }
}

@media only screen and (min-width: 1025px) {
  .info-main {
    margin: 0% 10%;
  }
  .user-safety .check ul {
    margin: 0 5%;
  }
}
@media only screen and (min-width: 1260px) {
}
</style>