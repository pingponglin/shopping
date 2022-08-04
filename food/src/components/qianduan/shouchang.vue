<template>
  <div>
    <div class="center">
      <div class="col-main">
        <div class="main-wrap">
          <div class="user-collection">
            <!--标题 -->
            <div class="am-cf am-padding">
              <div class="am-fl am-cf">
                <strong class="am-text-danger am-text-lg">我的收藏</strong> /
                <small>My&nbsp;Collection</small> <a class="am-badge am-badge-danger am-round">降价</a>
                <a class="am-badge am-badge-danger am-round">下架</a>
              </div>
            </div>
            <hr />

            <div class="you-like">
              <div class="s-content">

                <div class="s-item-wrap" v-for="items in footprint" :key="items.footprintid">
                  <div class="s-item">
                    <div class="s-pic">
                      <a href="#" class="s-pic-link">
                        <img
                          :src="'http://81.68.132.153:7070/img/'+items.Good.GoodImage"
                          :alt="items.Good.GoodfuName"
                           :title="items.Good.GoodfuName"
                          class="s-pic-img s-guess-item-img"
                        />
                        <span class="tip-title" v-if="items.Good.Goodstatus=='false'">已下架</span>
                           <span v-else></span>
                      </a>
                    </div>
                    <div class="s-info">
                      <div class="s-title">
                        <a
                          href="#"
                          :title="items.Good.GoodfuName"
                          >{{items.Good.GoodfuName}}</a
                        >
                      </div>
                      <div class="s-price-box">
                        <span class="s-price" style="line-height: 0px;margin-right: 26px;"
                          ><em class="s-price-sign">¥</em
                          ><em class="s-value">{{items.Good.GoodPrice}}</em></span
                        >
                        <span class="s-history-price" style="position: relative;bottom: 31px;left: 24px;"
                          ><em class="s-price-sign">¥</em
                          ><em class="s-value">{{items.Good.GoodPrcieper}}</em></span
                        >
                      </div>
                    </div>
                    <div class="s-tp">
                      <span class="ui-btn-loading-before" @click="getshopping(items)" target="_top">进入商品</span>
                      <i class="am-icon-trash"></i>
                      <span class="ui-btn-loading-before buy" @click="getdelete(items.Good.GoodfuName)">取消收藏</span>
                    </div>
                  </div>
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
      //接收用户id
      userid:"",
      //接收收藏夹的数据
      footprint:[]
    };
  },
  methods:{
    //根据用户查询所有的收藏
    getfootprint(){
       this.$axios.get('/api/Food/footprintid?id='+this.userid).then(d=>{
          if (d.data!="") {
            let dt=d.data;
          let arr1 = []; //存id
          //循环如果有相同的，就存一个，去重复
	for(let i in dt){
		if(arr1.indexOf(dt[i].Good.GoodfuName) == -1){
			arr1.push(dt[i].Good.GoodfuName);
			this.footprint.push(dt[i]);
		}
	}
          console.log(this.footprint);
          }
        });
    },
    //点击进入商品详情
    getshopping(sender){
       this.$router.push({
          path: '/qianduan/shopping',
          query: {
            ids: sender.Good.GoodName,
            namess: sender.Userxix.Userxixname
          }
        });
    },
    //取消收藏
    getdelete(id){
      this.$axios.get('/api/Food/footprintdelete?id='+id).then(s=>{
        if (s.data=="删除成功") {
          window.location.reload();
          this.$message({
          message: '取消收藏成功',
          type: 'success'
        });
        }
        else{
           this.$message({
          message: '取消收藏失败',
          type: 'success'
        });
        }
      })
    }
  },
  created(){
    this.userid=this.$route.query.userids;
    this.getfootprint();
  }
};
</script>

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

/*收藏夹*/
.you-like{ display:block;margin-bottom:5px;overflow:hidden;background: #fff;margin-top:15px ;}
.you-like .s-bar{font-size: 15px;line-height: 18px;padding: 11px 10px;position: relative;border-bottom:#E4EAEE solid 1px;  ;}
.am-badge {font-size:11px}
.you-like .s-content{ padding-top:20px; overflow:hidden;}
.s-item-wrap{width:100%}
.s-item .s-pic {width:120px;position: absolute;}
.s-item .s-info{float: left;margin-left:120px ;padding-top:5px ;}
.s-item {position: relative;margin: 0px 8px 10px 8px;background: #FFF none repeat scroll 0% 0%;border: 1px solid #E4EAEE;color: #595959;overflow: hidden;min-height: 120px;}
.s-item .s-pic .s-pic-link { margin:0px auto;overflow: hidden;text-align: center;}
.s-item .s-pic .s-pic-link img{ width:100%;}
.s-item .s-pic .tip-title{position: absolute;top:50%;left:50%;width:50px;height: 50px;margin-left:-25px;margin-top: -25px;border-radius:50% ;background: rgba(0, 0, 0, 0.5) none repeat scroll 0% 0%;
color:#fff ;text-align: center;vertical-align: middle;padding-top:15px;}


/*商品信息*/
.s-item .s-price-box {height:16px; overflow: hidden; margin: 5px 5px;line-height: 16px;position: absolute;bottom:5px;}
.s-item .s-price {font-size:15px; vertical-align: bottom;color: #F40;}
.s-item .s-price .s-price-sign {font-family: Arial; margin-right: 4px;}
.s-item .s-price .s-value {font-family: Verdana;font-weight: 700;}
.s-item .s-history-price {font-size:12px;vertical-align: bottom;color: #999;}
.s-item .s-history-price .s-price-sign {font-family: Arial;margin-right: 4px;}
.s-item .s-history-price .s-value {font-family: Verdana;text-decoration: line-through;font-weight: 400;}

/*好评*/
.s-item .s-title {font-size:15px;overflow:hidden;margin: 0px 8px 0px 8px;height:40px ;line-height:20px ;}
.s-item .s-extra-box {font-size: 12px; margin: 12px 8px 0px;height: 16px;line-height: 16px;color: #9C9C9C;}
.s-more-btn {color: #595959;border: 1px solid #E4EAEE; margin: 10px 7px 38px;text-align: center; cursor: pointer;font-size: 12px;height: 28px; line-height: 28px;background-color: #FFF;}

/*操作*/
.s-tp{position: absolute;right:10px;bottom:10px;}
.s-item .s-tp p,.s-history-price{display: none;}
.ui-btn-loading-before{display: inline-block;width: 65px;height: 20px; line-height: 20px;text-align: center;color: #999;font-size: 12px; border: 1px solid #D7D7D7;text-decoration: none;}
.ui-btn-loading-before.buy{display: none;}
.s-tp i{color:#F40;font-size: 16px;margin-left:10px ;}



@media only screen and (min-width:640px) 
{
.s-item-wrap{width:33.33%; float:left;}
.s-item .s-pic {width: 100%;position:relative;}	

.s-item .s-info {float: none; margin-left:0;padding-bottom:10px ;}	
.s-item .s-price-box {position: static;}	
.s-item .s-title {height:20px;overflow: hidden;white-space: nowrap;text-overflow: ellipsis;}
.s-price-box,.s-extra-box{text-align: center;}	
.s-info .s-title{font-size:14px ;}
.s-history-price{display: inline;}	
/*操作*/
.s-tp {position: absolute;right:0px;bottom:90px;width:100% ;left:0px ;}
.ui-btn-loading-before {cursor: pointer;width:50%;border: none;text-align: center;background: rgba(0, 0, 0, 0.5) none repeat scroll 0% 0%;
color: #FFF;}
.ui-btn-loading-before.buy{display:inline-block;position: absolute;right:-1px;}
.s-tp i{display: none;}
	
}	
@media only screen and (min-width:1025px) 
{
.s-item-wrap{width:25%; float:left;}
}

@media only screen and (min-width:1200px) 
{
.s-item-wrap{width:20%; float:left;}
}


	

</style>