<template>
  <div class="Login">
    <div class="login-boxtitle">
      <a href="home.html"
        ><img alt="logo" src="../assets/images/logobig.png" style="width:100px"
      /></a>
    </div>
    <div class="login-banner">
      <div class="login-main">
        <div class="login-banner-bg">
          <span></span><img src="../assets/images/big.jpg" />
        </div>
        <div class="login-box" style="height: 395px;">
          <h3 class="title" style="font-size: 21px;
    margin-bottom: 15px;">熙林食品零售商城</h3>
          <div class="clear"></div>
          <div class="login-form">
            <el-form
              :model="ruleForm"
              :rules="rules"
              ref="ruleForm"
              label-width="0"
              class="demo-ruleForm" style="background-color: #F8F8F8;"
            >
              <div class="user-name">
                <el-form-item prop="name">
                  <el-input
                    v-model="ruleForm.name "
                    prefix-icon="el-icon-user-solid" placeholder="手机/用户名"
                  ></el-input>
                </el-form-item>
              </div>
              <div class="user-pass" style="margin-top: 20px;">
                <el-form-item prop="password">
                  <el-input
                    v-model="ruleForm.password"
                    prefix-icon="el-icon-s-goods"
                    placeholder="请输入密码"
                    show-password
                  ></el-input>
                </el-form-item>
              </div>
              <div class="login-links" style="margin: 8px auto;">
      <a href="#" style="line-height: 43px;position: relative;left: 259px;" @click="wangjia">忘记密码</a>
      <router-link to="/register" class="zcnext am-fr am-btn-default">注册</router-link>
           
            <br />
          </div><div class="am-cf">
              <el-form-item>
                <el-button type="primary" class="am-btn am-btn-primary am-btn-sm" style="height:40px" @click="submitForm('ruleForm')"
                  >立即登录</el-button
                >
              </el-form-item></div>
            </el-form>
          </div>
        </div>
      </div>
    </div>

    <div class="footer">
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
    <el-dialog title="找回密码" :visible.sync="dialogVisible" width="30%">
      <el-form
        :model="ruleForms"
        label-width="100px"
        class="demo-ruleForm"
      >
        <el-form-item
          prop="name"
          label="用户名"
          style="position: relative; top: 0px; left: 0px"
        >
          <el-input
            v-model="ruleForms.Userxixphone"
            prefix-icon="el-icon-user-solid"
            placeholder="手机/用户名"
          ></el-input>
        </el-form-item>
        <el-form-item prop="yzms" label="验证码"
          style="position: relative; top: 0px; left: 0px">
                   <el-input
                        type="password"
                        v-model="ruleForms.yzms"
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
    top: -1px;">{{count}}</span></div></el-form-item>
      </el-form>
      <span slot="footer" class="dialog-footer">
        <el-button @click="dialogVisible = false">取 消</el-button>
        <el-button type="primary" @click="dengliu">确 定</el-button>
      </span>
    </el-dialog>
  </div>
</template>
<style scoped>
/* @import './assets/css/dlstyle.css' */
@import '../../src/assets/css/dlstyle.css';
@import '../../src/assets/AmazeUI-2.4.2/assets/css/amazeui.css';
</style>

<script>
export default {
  data() {
    return {
      show:true,   
         count:'',    
           timer:null ,
           sms:"",
      ruleForm: {
        name: "",
        password:"",
        checked:false
      }, 
      rules: {
        name: [
          { required: true, message: "请输入用户名和手机或邮箱", trigger: "blur" },
          // { min: 3, max: 5, message: "长度在 3 到 5 个字符", trigger: "blur" },
        ],
        password: [{ required: true, message: "请输入密码", trigger: "blur" }],
      },
      dialogVisible:false,
      ruleForms: {
        Userxixphone: "",
        yzms: "",
      }
    };
  },
  methods: {
    submitForm(formName) {
      // 1.将登录成功之后的token, 保存到客户端的sessionStorage 中
//1.1项目中出了登录之外的其他API接口，必须在登录之后才能访问
//1.2 token 只应在当前网站打开期间生效，所以将token 保存在sessionStorage 中
// 2.通过编程式导航跳转到后台主页，路由地址是/home

      this.$refs[formName].validate((valid) => {
        if (valid) {
          this.$axios.post('/api/Food/foodUser',this.$qstring.stringify({
              Userxixname:this.ruleForm.name,
              Userxixphone:this.ruleForm.name,
              Userxixemail:this.ruleForm.name,
              Usermima:this.ruleForm.password
          })).then(s=>{
            console.log(s); this.$router.push('/')
            
//  this.$session.set("key",s.data[0].Userxixname);
            if(s.data!=""){
 this.$message({
          message: '用户登录成功',
          type: 'success'
        });
        // window.location.reload();
        window.sessionStorage.setItem('token',s.data[0].Userxixname)
        console.log(s.data[0].Userxixname)
            }
            else{
         this.$axios.post('/api/Food/foodAdmin',this.$qstring.stringify({
              Adminname:this.ruleForm.name,
              Adminmima:this.ruleForm.password
          })).then(d=>{
            if(d.data!=""){
                window.sessionStorage.setItem('token',d.data[0].Adminname)
        //         this.$router.push({
        //   path:"/Admin",
        //   query:{n:d.data[0].Adminname}
        // })
        this.$router.push("/shou");
 this.$message({
          message: '管理员登录成功',
          type: 'success'
        });
            }
            else{
              this.$message({
          message: '登录失败',
          type: 'warning'
        });
            }
          }).catch(p=>{console.log(p)})
            }
          }).catch(p=>{console.log(p)});
          // alert("submit!");
        } else {
          console.log("error submit!!");
          this.$message({
          message: '登录失败',
          type: 'warning'
        });
          return false;
        }
      });
    },
    resetForm(formName) {
      this.$refs[formName].resetFields();
    },
    //忘记密码
    wangjia(){
     this.dialogVisible=true;
    },
    dengliu(){
       this.$axios.get('/api/Food/foodUsersphone?name='+this.ruleForms.Userxixphone).then(s=>{
         if (s.data!="") {
           if (this.ruleForms.yzms==this.sms) {
             this.$message.success("密码为："+s.data[0].Usermima);
           }
          else{
            this.$message.error('验证码错误');
          }
         }
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
  },
  created(){
    const tokenstr=window.sessionStorage.getItem('token');
    if (tokenstr!="") {
      this.$axios.get('/api/Food/adminname?names='+tokenstr+''
      ).then(s=>{
         console.log(s.data[0].Adminname)
         console.log(s.data[0].Adminmima)
         this.ruleForm.name=s.data[0].Adminname;
         this.ruleForm.password=s.data[0].Adminmima;
         this.ruleForm.checked=true;
      }).catch(d=>{
        console.log(d)
      })
    }
     console.log(tokenstr);
  }
};
</script>
