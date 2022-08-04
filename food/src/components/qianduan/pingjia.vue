<template>
  <div>
    <div class="center">
      <div class="col-main">
        <div class="main-wrap">
          <div class="user-comment">
            <!--标题 -->
            <div class="am-cf am-padding">
              <div class="am-fl am-cf">
                <strong class="am-text-danger am-text-lg">发表评论</strong> /
                <small>Make&nbsp;Comments</small>
              </div>
            </div>
            <hr />
            <div class="comment-main"   v-for="order in orderlist"
                :key="order.Orderid">
              <div
                class="comment-list"
                style="position: relative; top: 40px"
              
              >
                <div class="item-pic">
                  <a href="#" class="J_MakePoint">
                    <img
                      :src="
                        'http://81.68.132.153:7070/img/' + order.Good.GoodImage
                      "
                      class="itempic"
                    />
                  </a>
                </div>

                <div class="item-title">
                  <div class="item-name">
                    <a href="#">
                      <p class="item-basic-info">{{ order.Good.GoodfuName }}</p>
                    </a>
                  </div>
                  <div class="item-info">
                    <div class="info-little">
                      <span>类型：{{ order.Goodtypetwo.Goodtypetwoname }}</span>
                    </div>
                    <div class="item-price">
                      价格：<strong>{{ order.Good.GoodPrcieper }}元</strong>
                    </div>
                  </div>
                </div>
                <div class="clear"></div>
                <div class="item-comment">
                  <textarea
                    placeholder="请写下对宝贝的感受吧，对他人帮助很大哦！"
                   v-model="score.Scoreidcontent"></textarea>
                </div>
                <div class="filePic"></div>
                <div class="item-opinion">
                   
                 <div class="block">
   <span style="float:left">评分</span><el-rate
    v-model="value2"
    :colors="colors">
  </el-rate>
</div>
                </div>
              </div>
              <el-upload
                style="position: relative; left: 204px; bottom: 19px"
                action="http://81.68.132.153:7070/api/Food/Imgupload"
                list-type="picture-card"
                :file-list="fileList"
                :on-success="handleSuccess"
                :before-upload="beforeAvatarUpload"
                :on-preview="handlePictureCardPreview"
                :limit="3"
              >
                <i
                  class="el-icon-plus"
                  style="position: relative; left: 39px"
                ></i
                ><span style="position: relative; bottom: 30px; right: 16px"
                  >最多上传三张</span
                >
              </el-upload>
              <div class="info-btn">
                <div @click="tijiao(order.Orderid)"
                  class="am-btn am-btn-danger"
                  style="
                    width: 91px;
                    height: 38px;
                    text-align: center;
                    line-height: 36px;
                  "
                >
                  发表评论
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      //接收订单Id
      orderids: "",
      //接收订单数据
      orderlist: [],
      userids:"",
      fileList: [],
      value2: null,
        colors: ['#99A9BF', '#F7BA2A', '#FF9900'],  // 等同于 { 2: '#99A9BF', 4: { value: '#F7BA2A', excluded: true }, 5: '#FF9900' }
      //添加评价
      score:{
      Scoreidpf:"",
      Scoredate:"",
      Scoreidcontent:"",
      Userxixid:"",
       Goodid:"",
        Orderid:"",
         Scoreimage:"",
      }
    };
  },
  methods: {
    //根据id查询订单的数据
    orderdate() {
      this.$axios
        .get("/api/Food/ordersselect?id=" + this.orderids)
        .then((s) => {
          this.orderlist = s.data;
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
      // this.updateform.GoodImage=file.name;
      // this.dialogImageUrl="http://81.68.132.153:7070/"+file.name;
      let dd="";
      for (let i = 0; i < fileList.length; i++) {
        if (i==fileList.length-1) {
          dd+=fileList[i].name;
          console.log(dd);
        }else{
          dd+=fileList[i].name+"/";
          console.log(dd);}
      }
      this.score.Scoreimage=dd;
      console.log(this.score.Scoreimage);
    },
    handlePictureCardPreview(file) {
      // this.dialogImageUrl = file.url;
      // this.dialogVisible = true;
      console.log(file);
    },
    //添加评价
    tijiao(id){
        this.$axios
        .get("/api/Food/ordersselect?id=" + this.orderids)
        .then((s) => {
            if (s.data!="") {
                 this.score.Orderid=id;
          this.score.Scoreidpf=this.value2;
          this.score.Userxixid=this.userids;
          this.score.Goodid=s.data[0].Goodid;
          this.$axios.post('/api/Food/scoreADD',this.score).then(d=>{
          if (d.data=="添加成功") {
              this.$message({
          message: '评价成功',
          type: 'success'
        });
          this.$axios.get('/api/Food/orderyiwangc?id='+id).then(l=>{
            if (l=="已完成") {
              console.log(l.data)
            }
          });
          }
          else{
              this.$message({
          message: '评价失败',
          type: 'success'
        });
          }
          });
            }
         
        });
       
    }
  },
  created() {
        this.userids = this.$route.query.userids;
    this.orderids = this.$route.query.orderid;
    this.orderdate();
  },
};
</script>
<style scoped>
@charset "utf-8";
/* CSS Document */
.comment-main {
  padding-bottom: 10px;
}
.item-pic {
  width: 90px;
  height: 90px;
  border: 1px solid #eee;
  float: left;
  overflow: hidden;
  margin-left: 5px;
  margin-right: 10px;
}
textarea {
  width: 100%;
  margin: 10px 5px;
  min-height: 80px;
  border: 0px none;
  resize: none;
  outline: 0px none;
  overflow: hidden;
}
.filePic {
  width: 100px;
  padding: 10px 10px;
  position: relative;
  overflow: hidden;
}
.filePic .inputPic {
  cursor: pointer;
  opacity: 0;
  width: 100%;
  height: 100%;
  position: absolute;
  top: 0;
  left: 0;
}
.filePic span {
  display: none;
}

img {
  width: 100%;
}
.item-opinion {
  border-top: 1px solid #f5f8fa;
  width: 100%;
  overflow: hidden;
  padding: 10px 0px;
}
.item-opinion li {
  float: left;
  width: 33.33%;
  text-align: center;
  font-size: 14px;
  cursor: pointer;
}
.item-opinion li i {
  display: inline-block;
  width: 16px;
  height: 16px;
  margin-right: 5px;
}
.item-opinion li i.op1,
.item-opinion li i.op2 {
  background: url(../../assets/images/iconfont-evaluate.png);
  background-size: 16px 16px;
}
.item-opinion li i.op3 {
  background: url(../../assets/images/iconfont-bad.png);
  background-size: 16px 16px;
}

.item-opinion li i.op1.active {
  background: url(../../assets/images/iconfont-good.png);
  background-size: 16px 16px;
}
.item-opinion li i.op2.active {
  background: url(../../assets/images/iconfont-middle.png);
  background-size: 16px 16px;
}
.item-opinion li i.op3.active {
  background: url(../../assets/images/iconfont-badon.png);
  background-size: 16px 16px;
}

.info-btn {
  text-align: center;
}

@media only screen and (min-width: 640px) {
  /*多个商品评价*/
  .comment-list {
    position: relative;
    margin: 0px 5px;
    padding-bottom: 10px;
  }
  .item-pic {
    width: 150px;
    height: auto;
    float: none;
  }
  .item-title {
    width: 150px;
    overflow: hidden;
  }
  .item-pay-logis {
    display: none;
  }
  .item-name p,
  .comment-list .info-little span {
    height: 18px;
    line-height: 18px;
    overflow: hidden;
  }
  .item-opinion {
    position: absolute;
    left: 200px;
    top: 0px;
    right: 0px;
    width: auto;
    max-width: 600px;
  }
  .item-comment {
    position: absolute;
    left: 200px;
    top: 40px;
    right: 0px;
    max-width: 600px;
  }
  textarea {
    min-height: 120px;
    border: 1px solid #f5f8fa;
    padding: 10px;
    margin: 0px 0px;
  }
  .filePic {
    position: absolute;
    left: 200px;
    bottom: 10px;
    width: 120px;
  }
  .filePic span {
    display: block;
    cursor: pointer;
  }
  .filePic img {
    display: none;
  }
  .user-comment {
    max-width: 1000px;
    margin: 0px auto;
  }
}
</style>
<style scoped>
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
  /* border-bottom: 2px solid #f03726; */
  border-top: none;
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
    overflow: hidden;
    bottom: 20px;
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