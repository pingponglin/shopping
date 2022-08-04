<template>
  <div class="divs">
            <!--标题 -->
            <div class="am-cf am-padding">
              <div class="am-fl am-cf">
                <strong class="am-text-danger am-text-lg">个人资料</strong> /
                <small>Personal&nbsp;information</small>
              </div>
            </div>
            <hr />

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
                  alt=""
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

            <!--个人信息 -->
            <div class="info-main">
              <el-form
                :model="updateform"
                label-width="70px"
                class="demo-ruleForm"
                :rules="updateformRules"
                ref="updateformref"
              >
                <el-form-item
                  label="头像"
                  style="position: relative; top: 0px; left: 0px"
                  prop="Userxixnich"
                >
                  <el-upload
                    class="upload-demo"
                    action="http://81.68.132.153:7070/api/Food/Imgupload"
                    :file-list="fileList"
                    :on-success="handleSuccess"
                    :before-upload="beforeAvatarUpload"
                    :limit="1"
                    list-type="picture"
                  >
                    <el-button size="small" type="primary">点击上传</el-button>
                    <div slot="tip" class="el-upload__tip">
                      只能上传jpg/png文件，且不超过500kb
                    </div>
                  </el-upload>
                </el-form-item>
                <el-form-item
                  label="名称:"
                  style="position: relative; top: 0px; left: 0px"
                  prop="Userxixname"
                >
                  <el-input v-model="updateform.Userxixname"></el-input>
                </el-form-item>
                <el-form-item
                  label="性别:"
                  style="position: relative; top: 0px; left: 0px"
                  prop="Userxixgender"
                >
                  <el-input v-model="updateform.Userxixgender"></el-input>
                </el-form-item>
                <el-form-item
                  label="生日:"
                  style="position: relative; top: 0px; left: 0px"
                  prop="Userxixbirthday"
                >
                  <el-date-picker
                    v-model="updateform.Userxixbirthday"
                    type="date"
                    placeholder="选择日期"
                  >
                  </el-date-picker>
                </el-form-item>
                <el-form-item
                  label="电话"
                  style="position: relative; top: 0px; left: 0px"
                  prop="Userxixphone"
                >
                  <el-input v-model="updateform.Userxixphone"></el-input>
                </el-form-item>
                <el-form-item
                  label="邮箱"
                  style="position: relative; top: 0px; left: 0px"
                  prop="Userxixemail"
                >
                  <el-input v-model="updateform.Userxixemail"></el-input>
                </el-form-item>
              </el-form>
              <el-button
                style="margin-left: 250px"
                type="primary"
                @click="updateInfo"
                >保存修改</el-button
              >
            </div>
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
      //接收用户的id
      userid: "",
      //接收用户所有的数据
      getuserlist: [],
      updateform: {},
      //修改表单的验证规则
      updateformRules: {
		Userxixname: [
          { required: true, message: "请输入姓名", trigger: "blur" }
        ],
        Userxixgender: [
          { required: true, message: "请输入性别", trigger: "blur" }
        ],
		Userxixbirthday: [
          { required: true, message: "请输入生日", trigger: "blur" }
        ],
        Userxixphone: [
          { required: true, message: "请输入用户手机号", trigger: "blur" },
          { validator: checkMobile, trigger: "blur" },
        ],
        Userxixemail: [
          { required: true, message: "请输入用户邮箱", trigger: "blur" },
          { validator: checkEmail, trigger: "blur" },
        ]
      },
      fileList: [],
    };
  },
  methods: {
    getuser() {
      this.$axios
        .get("/api/Food/foodUsersid?pagenum=" + this.userid)
        .then((s) => {
          this.getuserlist = s.data;
          this.updateform = s.data[0];
          console.log(s.data);
        });
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
    handleSuccess(response, file, fileList) {
      console.log("上传文件夹名" + file.name);
      this.updateform.Userxixnich = file.name;
    },
	updateInfo(){
		this.$refs.updateformref.validate(valid=>{
        if (!valid) return
          //发起数据请求
        this.$axios.post('/api/Food/foodUsersUpdate',this.updateform
        ).then(d=>{
          if (d.data=="修改成功") {
            this.getuser();console.log(d.data);
            return this.$message.success('更新用户信息成功!');
            
          }
          else{
            return this.$message.error('更新用户信息失败!')
          }
          
        })
        console.log(valid)
        });
	}
  },
  created() {
    this.userid = this.$route.query.userids;
    this.getuser();
  },
};
</script>

<style scoped>
/* @import "../../assets/css/personal.css"; */
/* @import "../../assets/css/infstyle.css"; */
.divs {
  background: white;
}
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

/* CSS Document */

/*公共*/
html,
body,
div,
span,
applet,
object,
iframe,
h1,
h2,
h3,
h4,
h5,
h6,
p,
blockquote,
pre,
a,
abbr,
acronym,
address,
big,
cite,
code,
del,
dfn,
em,
img,
ins,
kbd,
q,
s,
samp,
small,
strike,
strong,
sub,
sup,
tt,
var,
b,
u,
i,
center,
dl,
dt,
dd,
ol,
ul,
li,
fieldset,
form,
label,
legend,
table,
caption,
tbody,
tfoot,
thead,
tr,
th,
td,
article,
aside,
canvas,
details,
embed,
figure,
figcaption,
footer,
header,
hgroup,
menu,
nav,
output,
ruby,
section,
summary,
time,
mark,
audio,
video {
  margin: 0;
  padding: 0;
  border: 0;
  font-size: 100%;
  font-size: 12px;
  font: inherit;
  vertical-align: baseline;
  font-family: arial, "Lantinghei SC", "Microsoft Yahei";
}
/* HTML5 display-role reset for older browsers */
article,
aside,
details,
figcaption,
figure,
footer,
header,
hgroup,
menu,
nav,
section,
main {
  display: block;
}
ul,
li,
ol {
  list-style: none;
}
dl,
dd {
  margin: auto;
}

html {
  width: 100%;
  height: 100%;
  -ms-text-size-adjust: none;
  -webkit-text-size-adjust: none;
  -moz-text-size-adjust: none;
  -o-text-size-adjust: none;
}
/*text-size-adjust不管屏幕怎么变文字大小不变*/

body {
  margin: 0;
  padding: 0;
  width: 100%;
  font-size: 12px;
  font-family: arial, "Lantinghei SC", "Microsoft Yahei";
  background: #f5f8fa none repeat scroll 0% 0%;
}

a:link,
a:visited {
  text-decoration: none;
  outline: none;
  color: #000;
}
/*所有超链接不要下划线*/
* {
  padding: 0;
  margin: 0;
}
； *,
*:after,
*:before {
  -webkit-box-sizing: border-box;
  -moz-box-sizing: border-box;
  -o-box-sizing: border-box;
  box-sizing: border-box;
}
/*任何标签、包括它前面、后面生成的内容都不要影响盒子的边框*/
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

.clear {
  clear: both;
}
header {
  display: none;
}

/*选项卡样式定义*/
.am-nav-tabs,
.am-tabs-bd {
  border-color: transparent;
}
.am-nav-tabs > li.am-active > a,
.am-nav-tabs > li.am-active > a:hover,
.am-nav-tabs > li.am-active > a:focus,
.am-nav-tabs > li > a:hover {
  color: #555555;
  background: none;
  border-color: transparent;
  cursor: default;
}
.am-nav-tabs > li > a {
  margin-right: 0px;
}
.am-nav-tabs > li.am-active {
  border-bottom: 2px solid #f03726;
}
.am-tabs-d2 .am-tabs-nav li {
  max-width: 216px;
}
/*选项卡样式*/
.am-nav-tabs > li {
  cursor: pointer;
}
.am-nav-tabs > li > a {
  padding: 0px 2px;
  margin: 0px 0px;
  text-align: center;
}

.nav-table {
  display: none;
}
/*主体部分*/
.center {
  width: 100%;
  margin: 0px auto;
  min-height: 1px;
  overflow: hidden;
}
aside,
.wrap-right,
.m-logistics,
.you-like {
  display: none;
}
.col-main {
  padding-bottom: 50px;
}
/*标题*/
.am-text-lg {
  font-size: 18px;
}
.am-padding {
  padding: 0px 10px;
}
.am-padding small {
  width: 50%;
}
hr {
  margin: 5px 0px;
}

/*表单布局*/
.am-form-label {
  width: 50px;
  float: left;
  text-align: right;
}
.am-form-content {
  margin-left: 65px;
}
.col-main {
  padding-top: 10px;
  background-color: #fff;
}

/*博客*/
.bloglist .am-u-md-9 {
  background: #fff;
}
.blog-main {
  max-width: 760px;
  margin: 0px auto;
}
.blog-sidebar {
  padding: 0px 0px;
}
.blog-list li {
  border: none;
}
.blog-list li p {
  white-space: nowrap; /* 不换行 */
  overflow: hidden;
  text-overflow: ellipsis;
}
.am-panel-hd {
  font-size: 18px;
  padding: 1rem 1rem;
}
.blog-title a {
  font-size: 20px;
  margin: 10px auto;
}
.blog-meta {
  font-size: 14px;
  text-align: right;
}
.blog-content p {
  font-size: 14px;
  line-height: 24px;
  text-indent: 2em;
}
.blog-content .Row li {
  width: 33.33%;
  float: left;
  padding: 5px;
}
.blog-content img {
  width: 100%;
}
.blog-tit p {
  color: rgb(89, 89, 89);
  text-indent: 0em;
  margin-top: 10px;
}
.blog-tit p span {
  font-family: Microsoft YaHei !important;
  color: rgb(192, 0, 0);
  font-size: 18px;
}
/*底部*/

.footer {
  display: none;
  text-align: center;
  border-top: 2px solid #f8f8f8;
  margin-top: 20px;
  padding-top: 5px;
}
.main-wrap {
  background-color: #fff;
}
@media only screen and (min-width: 640px) {
  html,
  body,
  div,
  span,
  applet,
  object,
  iframe,
  h1,
  h2,
  h3,
  h4,
  h5,
  h6,
  p,
  blockquote,
  pre,
  a,
  abbr,
  acronym,
  address,
  big,
  cite,
  code,
  del,
  dfn,
  em,
  img,
  ins,
  kbd,
  q,
  s,
  samp,
  small,
  strike,
  strong,
  sub,
  sup,
  tt,
  var,
  b,
  u,
  i,
  center,
  dl,
  dt,
  dd,
  ol,
  ul,
  li,
  fieldset,
  form,
  label,
  legend,
  table,
  caption,
  tbody,
  tfoot,
  thead,
  tr,
  th,
  td,
  article,
  aside,
  canvas,
  details,
  embed,
  figure,
  figcaption,
  footer,
  header,
  hgroup,
  menu,
  nav,
  output,
  ruby,
  section,
  summary,
  time,
  mark,
  audio,
  video {
    font-size: 14px;
  }

  /*头*/
  header {
    display: block;
  }
  header article {
    max-width: 1200px;
    margin: 0px auto;
  }
  .mt-logo .mt-tblogo {
    width: 20%;
    display: inline-block;
    vertical-align: middle;
  }
  .message-l {
    float: left;
  }
  .message-l .topMessage {
    padding: 0px 6px;
    height: 35px;
    line-height: 35px;
  }
  .message-r {
    float: right;
  }
  .message-r .topMessage {
    float: left;
    padding: 0px 6px;
    height: 35px;
    line-height: 35px;
  }
  /*浮动框*/
  .nav.white {
    width: 100%;
    margin: 0px auto;
  }
  .nav.white .logoBig {
    display: block;
    float: left;
    height: 56px;
    width: 115px;
    margin: 0px auto;
    margin-left: 5%;
  }
  .nav.white .logoBig img {
    width: 100%;
  }
  .my-cart {
    width: 46px;
    height: 46px;
  }

  #ai-topsearch {
    height: 46px;
  }
  .search-bar input {
    width: 80%;
    height: 46px;
  }
  .classified {
    display: none;
  }
  .nav.white {
    position: relative;
    top: 0px;
    z-index: 0;
  }

  /*搜索框*/
  .search-bar {
    height: 51px;
    margin: 0px 50px 0 120px;
    padding-left: 5%;
  }
  .search-bar form {
    border: 2px solid #f03726;
    max-width: 670px;
  }
  .search-bar input {
    padding-left: 5px;
    width: 80%;
    height: 46px;
    outline: none;
    font-size: 12px;
    border: none;
  }
  #ai-topsearch {
    width: 20%;
    height: 46px;
    border: 0px none;
    float: right;
    background: #f03726 none repeat scroll 0% 0%;
    color: #f5f5f2;
    font-size: 14px;
    cursor: pointer;
  }

  /*固定框架*/
  .center {
    width: 96%;
    max-width: 1000px;
    margin: 0px auto;
    min-height: 1px;
    margin-top: 15px;
  }

  /*表单布局*/
  .am-form-label {
    width: 100px;
    float: left;
  }
  .am-form-content {
    margin-left: 85px;
  }

  /*侧边栏*/
  aside {
    display: block;
    width: 130px;
    float: left;
    margin-left: -100%;
    padding-top: 10px;
  }
  aside ul {
    margin-left: 10px;
    margin-right: -10px;
    padding: 0px 8px;
    font-size: 14px;
    background: #fff;
    border-top: 5px solid #fec4d7;
  }
  aside a {
    display: block;
    overflow: hidden;
    text-decoration: none;
    line-height: 28px;
    color: #000;
    height: 28px;
  }
  aside ul li {
    text-align: center;
  }
  aside ul li.active a {
    color: #f69;
  }
  li.person {
    border-bottom: 1px solid #f5f8fa;
    padding-bottom: 10px;
    padding-top: 10px;
  }
  .person ul {
    padding-left: 6px;
    border: none;
    padding-top: 0px;
    padding-bottom: 0px;
    margin: 0px auto;
    font-size: 12px;
  }
  .person ul li a {
    color: #666;
  }
  /*主题*/
  .col-main {
    float: left;
    width: 100%;
    min-height: 1px;
    background: none;
    padding-bottom: 0px;
  }
  .main-wrap {
    position: relative;
    margin-left: 150px;
    overflow: hidden;
    min-height: 585px;
    background-color: #fff;
  }
  .am-fl.am-cf small {
    width: auto;
  }
  .am-padding {
    margin: 20px 0px;
  }
  .am-text-danger {
    color: #000;
  }
  /*底部*/
  .footer {
    text-align: left;
    display: block;
    position: relative;
    margin: 0px auto;
    padding: 7px 0px 9px;
    border-top: 2px solid #ff5400;
    margin-top: 20px;
  }
  .footer .footer-bd p,
  .footer .footer-hd p {
    margin-bottom: 8px;
    line-height: 27px;
    border-bottom: 1px solid #ddd;
    text-align: left;
  }
  .footer .footer-hd a {
    margin: 0px 4px;
    white-space: nowrap;
    color: #6c6c6c;
  }
  .footer .footer-hd b {
    margin: 0px 3px;
    font-weight: 400;
    color: #ddd;
  }
  .footer .footer-bd p {
    border-bottom: none;
  }
  .footer-bd {
    display: block;
  }

  /*博客*/
  .blog-main {
    margin-top: 10px;
  }
  .blog-sidebar {
    padding: 0px 10px;
  }
}

@media only screen and (min-width: 1025px) {
  .nav.white {
    padding-left: 0px;
    max-width: 1000px;
    margin: 0px auto;
  }
  .nav.white .logoBig {
    display: block;
    float: left;
    height: 90px;
    width: 200px;
    margin-left: 0px;
  }
  .nav.white .logoBig li {
    float: left;
  }
  .search-bar {
    height: 90px;
    padding: 20px 70px 0 230px;
    margin: auto;
  }

  /*分类*/
  .nav-table {
    max-width: 1000px;
    margin: 0px auto;
    height: 45px;
    position: relative;
    overflow: hidden;
    display: block;
    margin-top: 10px;
  }
  .nav-table .all-goods {
    font-size: 16px;
  }
  .long-title {
    background: #d2364c;
    color: #fff;
    height: 45px;
    line-height: 45px;
    display: block;
    position: absolute;
    width: 150px;
    text-align: center;
    font-size: 16px;
    top: 0px;
    z-index: 6;
  }
  .nav-cont {
    position: absolute;
    padding-left: 150px;
    display: block;
    width: 100%;
    top: 0px;
  }
  .nav-cont li {
    float: left;
    height: 45px;
    line-height: 45px;
  }
  .nav-cont li::before {
    content: "\20";
    display: inline-block;
    height: 16px;
    border-right: 1px solid #d9d9d9;
    width: 0;
    vertical-align: middle;
    margin-left: -1px;
  }
  .nav-cont li a {
    font-size: 16px;
    color: #333;
    line-height: 36px;
    margin-left: -1px;
    padding: 0 25px;
    text-decoration: none;
    font-weight: 700;
    display: inline-block;
    vertical-align: middle;
  }

  .nav-cont .nav-extra {
    position: absolute;
    right: 0px;
    top: 6px;
    font-size: 16px;
    color: #fcff00;
    line-height: 33px;
    height: 33px;
    width: 160px;
    text-align: center;
    background: url(../../assets/images/extra.png);
    cursor: pointer;
  }
  .nav-cont .nav-extra i.nav-user {
    background: #000;
    color: #fff;
    width: 33px;
    height: 33px;
    border-radius: 33px;
    position: absolute;
    left: -28px;
    z-index: 99;
    padding: 5px;
    overflow: hidden;
  }
  .nav-cont .nav-extra b {
    display: block;
    position: absolute;
    width: 45px;
    height: 45px;
    border-radius: 45px;
    z-index: 1;
    left: -33px;
    top: -8px;
    background: #fff;
  }
  b.line {
    display: block;
    width: 100%;
    height: 2px;
    border-bottom: 2px solid #d2364c;
  }

  .bloglist {
    padding-top: 20px;
  }
  .blog-content p {
    font-size: 16px;
    line-height: 24px;
  }
}

@media only screen and (min-width: 1260px) {
  /*分类*/
  .nav-table,
  .footer {
    max-width: 1200px;
  }
  .long-title {
    width: 180px;
  }
  .nav-cont {
    padding-left: 180px;
  }
  /*固定框架*/
  .center {
    width: 96%;
    max-width: 1200px;
    margin: 0px auto;
    min-height: 1px;
    margin-top: 15px;
  }
  aside {
    width: 160px;
  }
  .main-wrap {
    margin-left: 180px;
  }
  .am-container,
  .bloglist {
    max-width: 1200px;
  }
  /*博客*/
  .blog-main {
    margin-top: 30px;
  }
}
</style>