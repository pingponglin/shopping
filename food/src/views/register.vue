<template>
  <!-- 注册 -->

  <div id="register">
    <div class="login-boxtitle">
      <a href="home/demo.html"
        ><img alt="" src="../assets/images/logobig.png" style="width:100px"
      /></a>
    </div>
    <div class="res-banner">
      <div class="res-main">
        <div class="login-banner-bg">
          <span></span><img src="../assets/images/big.jpg" />
        </div>
        <div class="login-box">
          <div class="am-tabs" id="doc-my-tabs">
            <ul class="am-tabs-nav am-nav am-nav-tabs am-nav-justify">
              <li class="am-active"><a href="" style="font-size: 16px;
    font-weight: 600;margin-left: 103px;">手机号注册</a></li>
            </ul>

            <div class="am-tabs-bd" style="border: none">
              <div class="am-tab-panel am-active">
                <el-form
                  :model="ruleForm"
                  :rules="rules"
                  ref="ruleForm"
                  class="demo-ruleForm"
                  style="background-color: #f8f8f8"
                >
                  <div class="user-phone">
                    <el-form-item prop="name">
                      <el-input
                        v-model="ruleForm.Userxixphone"
                        prefix-icon="el-icon-user-solid"
                        placeholder="请输入手机号"
                      ></el-input>
                    </el-form-item>
                  </div>
                  <div class="verification" style="margin-top: 15px">
                    <label for="code"><i class="am-icon-code-fork"></i></label>
                    <el-form-item prop="yzms">
                   <el-input
                        type="password"
                        v-model="ruleForm.yzms"
                        placeholder="输入验证码" style="width: 193px;float: left;"
                        prefix-icon="el-icon-s-goods"
                        autocomplete="off"
                      ></el-input>
                      <div style="width: 91px;
    background-color: #FF9400;
    height: 38px;
    float: right;
    color: white;">
                 <span v-show="show" @click="getCode" style="position: relative;
    left: 14px;">获取验证码</span>
 <span v-show="!show" class="count" style="position: relative;
    left: 33px;
    top: -1px;">{{count}} s</span></div></el-form-item>

                  </div>
                  <div class="user-pass" style="margin-top: 15px">
                    <el-form-item prop="pass">
                      <el-input
                        type="password"
                        v-model="ruleForm.Usermima"
                        placeholder="设置密码"
                        prefix-icon="el-icon-s-goods"
                        autocomplete="off"
                      ></el-input>
                    </el-form-item>
                  </div>
                  <div class="user-pass" style="margin-top: 15px">
                     <el-form-item prop="checkPass">
                      <el-input
                        type="password"
                        v-model="ruleForm.checkPass"
                        placeholder="确认密码"
                        prefix-icon="el-icon-s-goods"
                        autocomplete="off"
                      ></el-input>
                    </el-form-item>
                  </div>
          
                <div class="login-links">
                  <el-checkbox
                      v-model="checked"
                      id="remember-me"
                      style="background-color: #f8f8f8"
                      >点击表示您同意商城《服务协议》</el-checkbox
                    >
                </div>
                <div class="am-cf">
                  <el-form-item>
                      <el-button
                        type="primary"
                        class="am-btn am-btn-primary am-btn-sm"
                        style="height: 40px"
                        @click="submitForm('ruleForm')"
                        >立即创建</el-button
                      >
                    </el-form-item>
                </div></el-form
                >
              </div>
            </div>
          </div>
        </div>
      </div>

      <div class="footer" style="position: relative;top: 111px;">
        <div class="footer-hd">
          <p>
            <a href="# ">恒望科技</a>
            <b>|</b>
            <a href="# ">商城首页</a>
            <b>|</b>
            <a href="# ">支付宝</a>
            <b>|</b>
            <a href="# ">物流</a>
          </p>
        </div>
        <div class="footer-bd">
          <p>
            <a href="# ">关于恒望</a>
            <a href="# ">合作伙伴</a>
            <a href="# ">联系我们</a>
            <a href="# ">网站地图</a>
            <em>© 2015-2025 Hengwang.com 版权所有</em>
          </p>
        </div>
      </div>
    </div>
  </div>
</template>
<style scoped>
@import '../../src/assets/css/dlstyle.css';
@import '../../src/assets/AmazeUI-2.4.2/assets/css/amazeui.min.css';
.am-nav-tabs.am-nav-justify > .am-active> a, .am-nav-tabs.am-nav-justify>.am-active>a:focus, .am-nav-tabs.am-nav-justify>.am-active>a:hover, .am-nav-tabs>li.am-active>a, .am-nav-tabs>li.am-active>a:focus, .am-nav-tabs>li.am-active>a:hover {
    margin-right: 0px;
    border-bottom: none;
    border-radius: 0px;
}
.am-nav-tabs.am-nav-justify>li>a {
    margin-right: 0;
    border-bottom: none;
    border-radius: 0;
}
.am-nav-tabs>li.am-active>a, .am-nav-tabs>li.am-active>a:focus, .am-nav-tabs>li.am-active>a:hover {
    color: #555;
    background-color: #fff;
    border: none;
    border-bottom-color: transparent;
    cursor: default;
}
@media only screen and (min-width: 1025px){
.am-nav-tabs > li.am-active {
    border-top: none !important;
    border-bottom: none;
}}
@media only screen and (min-width: 1260px){
ul.am-tabs-nav.am-nav.am-nav-tabs {
    left: auto;
    right: auto;
    width: 100%;
}}
</style>
<script>
// import '../assets/AmazeUI-2.4.2/assets/js/amazeui.min.js';
// import '../../src/assets/AmazeUI-2.4.2/assets/js/amazeui.min.js';
import $ from "jquery";
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
    var validatePass = (rule, value, callback) => {
        if (value === '') {
          callback(new Error('请输入密码'));
        } else {
          if (this.ruleForm.checkPass !== '') {
            this.$refs.ruleForm.validateField('checkPass');
          }
          callback();
        }
      };
      var validatePass2 = (rule, value, callback) => {
        if (value === '') {
          callback(new Error('请再次输入密码'));
        } else if (value !== this.ruleForm.Usermima) {
          callback(new Error('两次输入密码不一致!'));
        } else {
          callback();
        }
      };
      var validatePasss = (rule, value, callback) => {
        if (value === '') {
          callback(new Error('请输入密码'));
        } else {
          if (this.ruleForm1.checkPass !== '') {
            this.$refs.ruleForm1.validateField('checkPass');
          }
          callback();
        }
      };
      var validatePasss2 = (rule, value, callback) => {
        if (value === '') {
          callback(new Error('请再次输入密码'));
        } else if (value !== this.ruleForm1.Usermima) {
          callback(new Error('两次输入密码不一致!'));
        } else {
          callback();
        }
      };
    return {
       show:true,   
         count:'',    
           timer:null,
           //手机号注册
      ruleForm: {
        Userxixphone:"",
        yzms:"",
        Usermima: "",
        checkPass: "",
      },
      //是否点击表示您同意商城《服务协议
      checked:"",
       checked1:"",
       //验证码
       sms:"",
      rules: {
        Userxixphone:[
          { required: true, message: "请输入用户手机号", trigger: "blur" },
          { validator: checkMobile, trigger: "blur" }
          ],
        yzms:[ { required: true, message: '请填写验证码', trigger: 'blur' }],
        Usermima: [{ validator: validatePass, trigger: "blur" }],
        checkPass: [{ validator: validatePass2, trigger: "blur" }],
      },
      //邮箱注册
       ruleForm1: {
        Userxixemail: "",
        Usermima: "",
        checkPass: "",
      },
       rules1: {
        Userxixemail: [
          { required: true, message: "请输入邮箱地址", trigger: "blur" },
          {
            type: "email",
            message: "请输入正确的邮箱地址",
            trigger: ["blur", "change"],
          },
        ],
        Usermima: [{ validator: validatePasss, trigger: "blur" }],
        checkPass: [{ validator: validatePasss2, trigger: "blur" }],
      }
    };
  },
  methods: {
    //手机注册
    submitForm(formName) {
      this.$refs[formName].validate((valid) => {
        if (valid) {
         if (this.checked==true) {
           if (this.ruleForm.yzms==this.sms) {
              this.$axios.post('/api/Food/fooduseradd',this.ruleForm).then(s=>{
            if (s.data=="添加成功") {
               this.$message.success("添加成功");
               this.$router.push("/Login");
            }
            else{
              this.$message.error("添加失败");
            }
          });
           }
           else{
             this.$message.error("请输入正确的验证码");
           }
         }
         else{
           this.$message.error("请点击表示您同意商城《服务协议》");
         }
        } else {
          console.log("error submit!!");
          return false;
        }
      });
    },
    //邮箱注册
    submitForm1(formName) {
      
      this.$refs[formName].validate((valid) => {
        if (valid) {
        if (this.checked1==true) {
          this.$axios.post('/api/Food/fooduseradd',this.ruleForm1).then(s=>{
            if (s.data=="添加成功") {
               this.$message.success("添加成功");
               this.$router.push("/Login");
            }
            else{
              this.$message.error("添加失败");
            }
          });
        }
        else{
           this.$message.error("请点击表示您同意商城《服务协议》");
        }
        } else {
          console.log("error submit!!");
          return false;
        }
      });
    },
    resetForm(formName) {
      this.$refs[formName].resetFields();
    },
    //验证码倒计时
    getCode(){
               const TIME_COUNT = 60;
               this.$axios.get('/api/Food/SendSMS?phone='+this.ruleForm.Userxixphone).then(s=>{
              // console.log(s.data.sms);
              if (s.data.Msg=="OK") {
                 this.sms=s.data.sms;
              console.log(this.sms);
              }
             
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
  },
  created(){
  }
};
$(function () {
  $("#doc-my-tabs").tabs();
});
</script>
