<template>
  <div class="divs">
    <!--头 -->
    <!--头 -->
    <header>
      <article>
        <div class="mt-logo">
          <!--顶部导航条 -->
          <div class="am-container header">
            <ul class="message-r">
              <div class="topMessage home">
                <div class="menu-hd">
                  <a href="http://81.68.137.46:8000/" target="_top" class="h"
                    >商城首页</a
                  >
                </div>
              </div>
              <div class="topMessage my-shangcheng">
                <div class="menu-hd MyShangcheng">
                  <a href="#" target="_top" @click="s"
                    ><i class="am-icon-user am-icon-fw"></i>个人中心</a
                  >
                </div>
              </div>
              <div class="topMessage mini-cart">
                <div class="menu-hd">
                  <a id="mc-menu-hd" href="#" target="_top" @click="goodshopp"
                    ><i class="am-icon-shopping-cart am-icon-fw"></i
                    ><span>购物车</span
                    ><strong id="J_MiniCartNum" class="h"></strong></a
                  >
                </div>
              </div>
              <div class="topMessage favorite">
                <div class="menu-hd">
                  <a href="#" target="_top" @click="goodfoot"
                    ><i class="am-icon-heart am-icon-fw"></i
                    ><span>收藏夹</span></a
                  >
                </div>
              </div>
              <div class="topMessage favorite">
                <div class="menu-hd">
                  <a href="#" target="_top"><span @click="tui">退出</span></a>
                </div>
              </div>
            </ul>
          </div>

          <!--悬浮搜索框-->

          <div class="nav white">
            <div class="logoBig">
              <li><img src="../../assets/images/logobig.png" /></li>
            </div>

            <div class="search-bar pr">
              <a name="index_none_header_sysc" href="#"></a>
              <form>
                <input
                  id="searchInput"
                  name="index_none_header_sysc"
                  type="text"
                  placeholder="搜索"
                  autocomplete="off"
                />
                <input
                  id="ai-topsearch"
                  class="submit am-btn"
                  value="搜索"
                  index="1" @click="shuosuo"
                  type="submit" style="text-align: center;"
                />
              </form>
            </div>
          </div>

          <div class="clear"></div>
        </div>
      </article>
    </header>
    <div class="nav-table">
      <div class="long-title"><span class="all-goods">全部分类</span></div>
      <div class="nav-cont">
        <ul>
            <li class="index"><a href="http://81.68.132.153:7070/">首页</a></li>
            <li class="qc"><a href="https://www.tmall.com/?spm=a21bo.21814703.201859.1.49fa11d9BdGwQk" target="_blank">天猫</a></li>
            <li class="qc"><a target="_blank" href="https://pages.tmall.com/wow/a/act/ju/dailygroup/2199/wupr?wh_pid=daily-222239&bid=3&spm=a21bo.21814703.201859.2.49fa11d9BdGwQk">聚划算</a></li>
            <li class="qc"><a target="_blank" href="https://chaoshi.tmall.com/?spm=a21bo.21814703.201859.3.49fa11d9BdGwQk">天猫超市</a></li>
            <li class="qc last"><a target="_blank" href="https://www.fliggy.com/?spm=a21bo.21814703.201859.5.49fa11d9BdGwQk">飞猪旅行</a></li>
        </ul>
       
      </div>
    </div>
    <b class="line"></b>
    <div class="center">
      <div class="col-main">
        <div class="main-wrap">
           <div class="user-info">
           <router-view></router-view>
           </div>
        </div>
        <!--底部-->
        <div class="footer">
          <div class="footer-hd">
            <p>
              <a href="#">恒望科技</a>
              <b>|</b>
              <a href="#">商城首页</a>
              <b>|</b>
              <a href="#">支付宝</a>
              <b>|</b>
              <a href="#">物流</a>
            </p>
          </div>
          <div class="footer-bd">
            <p>
              <a href="#">关于恒望</a>
              <a href="#">合作伙伴</a>
              <a href="#">联系我们</a>
              <a href="#">网站地图</a>
              <em>© 2015-2025 Hengwang.com 版权所有</em>
            </p>
          </div>
        </div>
      </div>

      <aside class="menu">
        <ul>
          <li class="person">
            <a href="#">个人中心</a>
          </li>
          <li class="person">
            <a href="#">个人资料</a>
            <ul>
              <li class="sds"><a href="#" class="dianj" @click="security">个人信息</a></li>
              <li class="sds"><a href="#" class="dianj" @click="usersafety">安全设置</a></li>
              <li class="sds"><a href="#" class="dianj" @click="userdizhi">收货地址</a></li>
            </ul>
          </li>
          <li class="person">
            <a href="#">我的交易</a>
            <ul>
              <li class="sds"><a href="#" class="dianj" @click="userorder">订单管理</a></li>
              <li class="sds"><a href="#" class="dianj" @click="ordertuihuos">退款售后</a></li>
            </ul>
          </li>
          <!-- <li class="person">
            <a href="#">我的资产</a>
            <ul>
              <li class="sds"><a href="#" class="dianj">账单明细</a></li>
            </ul>
          </li> -->

          <li class="person">
            <a href="#">我的小窝</a>
            <ul>
              <li class="sds"><a href="#" @click="usershouchang" class="dianj">收藏</a></li>
              <!-- <li class="sds"><a href="#" class="dianj">足迹</a></li> -->
              <li class="sds"><a href="#" class="dianj" @click="pingjia">评价</a></li>
            </ul>
          </li>
        </ul>
      </aside>
    </div>
  </div>
</template>

<script>
import $ from 'jquery';
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
$(function(){
  //  $(".dianj").each(function(index){//便利对象
  //    if ($(".dianj").eq(index).html()=="收藏") {
  //      $(".sds").eq(index).addClass("active");//添加当前元素的样式
  //    }
  //    if ($(".dianj").eq(index).html()=="个人中心") {
  //      $(".sds").eq(index).addClass("active");//添加当前元素的样式
  //    }
  //           });
   $(".sds").each(function(index){//便利对象
                $(this).click(function(){//点击触发事件
                    $(".sds").removeClass("active");//删除当前元素的样式
                    $(".sds").eq(index).addClass("active");//添加当前元素的样式
                });
            });
})
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
        ]
      },
      fileList: [],
      namess:""
    };
  },
  components: {
    // tou,
  },
  methods: {
    //查询用户所有
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
    //用户提交
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
	},
  //跳转用户安全
  usersafety(){
   this.$router.push({
                path: "/qianduan/usersafety",
                query: {
                  userids: this.userid,
                },
              });
  },
  //跳转到用户信息
  security(){
       this.$router.push({
                path: "/qianduan/security",
                query: {
                  userids: this.userid,
                },
              });
  },
  //跳转到收货地址
  userdizhi(){
 this.$router.push({
                path: "/qianduan/userdizhi",
                query: {
                  userids: this.userid,
                },
              });
  },
  //跳转到收藏夹
  usershouchang(){
    this.$router.push({
                path: "/qianduan/shouchang",
                query: {
                  userids: this.userid,
                },
              });
  },
  //跳转到购物车
  goodshopp(){
        this.$router.push({
                path: "/qianduan/shopgowuche",
                query: {
                  userids: this.userid,
                },
              });
    },
    //跳转到收藏夹
  goodfoot(){
        this.$router.push({
                path: "/qianduan/shouchang",
                query: {
                  userids: this.userid,
                },
              });
    },
    //跳转到订单管理
    userorder(){
 this.$router.push({
                path: "/qianduan/userorder",
                query: {
                  userids: this.userid,
                },
              });
    },
    //跳转到退货管理
    ordertuihuos(){
      this.$router.push({
                path: "/qianduan/tuihuoguanli",
                query: {
                  userids: this.userid,
                },
              });
    },
    //跳转到评价
    pingjia(){
 this.$router.push({
                path: "/qianduan/pingjiaguanli",
                query: {
                  id: this.userid,
                },
              });
    },
    //刷新
     s() {
      window.location.reload();
    },
    //退出
    tui() {
      window.sessionStorage.clear();
      this.$router.push("/Login");
    },
     getnames(){
     this.$axios.get('/api/Food/foodUsersid?pagenum='+this.userid).then(s=>{
       this.namess=s.data[0].Userxixname;
     });
    },
    //跳到搜索页面
    shuosuo(){
       this.$router.push({
          path: '/qianduan/search',
          query: {
            namess: this.namess
          }
        });
            //  this.$router.push('/qianduan/search');
    },
  },
  created() {
     if (location.href.indexOf("#reloaded") == -1) {
      location.href = location.href + "#reloaded";
      location.reload();
    }
    this.userid = this.$route.query.userids;
    this.getuser();
    this.getnames()
  },
};
</script>

<style scoped>
/* @import "../../assets/css/personal.css"; */
/* @import "../../assets/css/infstyle.css"; */
.dianj{
  color: #f69;
}
.divs {
  background: #f5f8fa none repeat scroll 0% 0%;
}
/* CSS Document */

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