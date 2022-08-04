<template>
  <div>
    <div class="main-wrap">
      <!--标题 -->
      <div class="am-cf am-padding">
        <div class="am-fl am-cf">
          <strong class="am-text-danger am-text-lg">退换货申请</strong> /
          <small>Apply&nbsp;for&nbsp;returns</small>
        </div>
      </div>
      <hr />
      <div class="comment-list">
        <!--进度条-->
        <div class="m-progress">  
          <div class="m-progress-list">
            <el-steps  :active="nums" finish-status="success">
  <el-step title="买家申请退款"></el-step>
  <el-step title="商家处理退款申请"></el-step>
  <el-step title="退款成功"></el-step>
</el-steps>
</div>
        </div>
        
        <div class="refund-aside" :style="di" v-for="item in orderdate" :key="item.Orderid">
          <div class="item-pic">
            <a href="#" class="J_MakePoint">
              <img   :src="'http://81.68.132.153:7070/img/'+item.Good.GoodImage" class="itempic" />
            </a>
          </div>

          <div class="item-title">
            <div class="item-name">
              <a href="#">
                <p class="item-basic-info">
                 {{item.Good.GoodfuName}}
                </p>
              </a>
            </div>
            <div class="info-little">
              <span> 类型：{{item.Good.GoodfuName}}</span>
            </div>
          </div>
          <div class="item-info">
            <div class="item-ordernumber">
              <span class="info-title">订单编号：</span><a>{{item.Ordername}}</a>
            </div>
            <div class="item-price">
              <span class="info-title"
                >价&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;格：</span
              ><span class="price">{{item.Good.GoodPrcieper}}元</span> <span class="number">×{{item.Ordernum}}</span
              ><span class="item-title">(数量)</span>
            </div>
            <div class="item-amountall">
              <span class="info-title"
                >总&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;计：</span
              ><span class="amountall">{{item.Ordersum}}元</span>
            </div>
            <div class="item-time">
              <span class="info-title">成交时间：</span
              ><span class="time">{{item.Ordertime | dateFormat }}</span>
            </div>
          </div>
          <div class="clear"></div>
        </div>

        <div class="refund-main" :style="di">
          <div class="item-comment">
            <div class="am-form-group">
              <label for="refund-type" class="am-form-label">退款类型</label>
              <div class="am-form-content">
                <el-select v-model="value1" placeholder="请选择">
    <el-option
      v-for="item in options1"
      :key="item.value"
      :label="item.label"
      :value="item.value">
    </el-option>
  </el-select>
              </div>
            </div>

            <div class="am-form-group">
              <label for="refund-reason" class="am-form-label">退款原因</label>
              <div class="am-form-content">
                <el-select v-model="value" placeholder="请选择退款原因">
    <el-option
      v-for="item in options"
      :key="item.value"
      :label="item.label"
      :value="item.value">
    </el-option>
  </el-select>
              </div>
            </div>

            <div class="am-form-group">
              <label for="refund-money" class="am-form-label"
                >退款金额<span>（不可修改）</span></label
              >
              <div class="am-form-content">
                <input
                  type="text"
                  id="refund-money"
                  readonly="readonly"
                  v-model="sums"
                />
              </div>
            </div>
            <div class="am-form-group">
              <label for="refund-info" class="am-form-label"
                >退款说明<span>（可不填）</span></label
              >
              <div class="am-form-content">
                 <editor class="editor" v-model="content" style="height:300px"></editor>
              </div>
            </div>
          </div>
          <div class="refund-tip">
              <el-upload
  action="http://81.68.132.153:7070/api/Food/Imgupload"
  list-type="picture-card"
    :file-list="fileList"
  :on-success="handleSuccess"
  :before-upload="beforeAvatarUpload"
    :on-preview="handlePictureCardPreview"
  :limit="3"
  >
  
  <i class="el-icon-plus" style="position: relative;
    left: 39px;"></i><span style="position: relative;
    bottom: 30px;
    right: 16px;">最多上传三张</span>
</el-upload>
<el-dialog :visible.sync="dialogVisible">
  <img width="100%" :src="dialogImageUrl" alt="">
</el-dialog>
          </div>
          <div class="info-btn">
            <el-button class="am-btn am-btn-danger" type="primary" @click="tijiao">提交申请</el-button>
          
          </div>
        </div>
        <div class="chuli" :style="dis">{{sizes}}</div>
      </div>  <p v-html="content" id="fuwen" style="display: none;"></p>
      <div class="clear"></div>
    </div>
  </div>
</template>

<script>
import editor from '../editor.vue'
import $ from 'jquery'
export default {
  data() {
    return {
       content: '',
    //接收订单id
    userid:"" ,
      dialogImageUrl: '',
        dialogVisible: false,
         fileList:[],
         //接收订单的数据
         orderdate:[],
         //下拉框
          options: [ {
          value: '不想要了',
          label: '不想要了'
        }, {
          value: '买错了',
          label: '买错了'
        }, {
          value: '没收到货',
          label: '没收到货'
        }, {
          value: '与说明不符',
          label: '与说明不符'
        }],
        //接收退货原因
        value: '',
        options1: [{
          value: '仅退款',
          label: '仅退款'
        }, {
          value: '退款/退货',
          label: '退款/退货'
        }],
        //退货类型
        value1: '',
        //总金额
        sums:"",
        //接收添加的数据
        ordertuihuoadd:{
          Goodid:"",
          Ordertuihuomoneys:"",
          Ordertuihuostatus:"",
          Ordertuihuodate:"",
          Orderid:"",
          Ordertuihuoyuangyi:"",
          OrdertuihuoImage:"",
          Ordertuihuotype:"",
          Ordertuihuoshuomin:""
        },
        //进度条
        nums:1,
        //是否隐藏
        di:"",
        //商家处理是否隐藏
        dis:"",
        //商家处理的字
        sizes:"商家正在处理中，请耐心等待！"
    };
  },
components:{
  editor
},
  methods: {
     submit () {
    console.log(this.content);
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
      handleSuccess(response,file,fileList){
console.log("上传文件夹名"+file.name);
// this.updateform.GoodImage=file.name;
this.dialogImageUrl="http://81.68.132.153:7070/img"+file.name;
let dd="";
for (let i = 0; i < fileList.length; i++) {
  if (i==fileList.length-1) {
    dd+=fileList[i].name;
    console.log(dd);
  }else{
    dd+=fileList[i].name+"/";
    console.log(dd);}
}
this.ordertuihuoadd.OrdertuihuoImage=dd;
console.log(this.ordertuihuoadd.OrdertuihuoImage);
      },
      handlePictureCardPreview(file) {
        this.dialogImageUrl = file.url;
        this.dialogVisible = true;
      },
      //获取根据订单id查询的数据
      orderlist(){
        this.$axios.get('/api/Food/ordersselect?id='+this.userid).then(s=>{
          if (s.data!="") {
            this.orderdate=s.data;
            this.sums=s.data[0].Ordersum;
            console.log(this.orderdate);
          }
        })
      },
      //添加退货
      tijiao(){
      //获取退货说明
      var suo=$("#fuwen");
      console.log(suo[0].innerText);
       this.ordertuihuoadd.Ordertuihuoshuomin=suo[0].innerText;
       this.ordertuihuoadd.Ordertuihuotype=this.value1;//退货类型
       this.ordertuihuoadd.Ordertuihuoyuangyi=this.value;//退货原因
        this.ordertuihuoadd.Ordertuihuomoneys=this.sums;//退货金额
         this.ordertuihuoadd.Goodid=this.orderdate[0].Good.Goodid;//退货商品id
        this.ordertuihuoadd.Orderid=this.orderdate[0].Orderid;//退货订单id
        this.$axios.post('/api/Food/ordertuihuoAdd',this.ordertuihuoadd).then(s=>{
            if (s.data=="添加成功") {
               this.$message({
          message: '提交申请成功,请耐心等待!',
          type: 'success'
        });
        this.nums=2;
        this.di="display: none;";
        this.ordertuihuosstatus();
            }
            else{
              this.$message({
          message: '提交申请失败',
          type: 'success'
        });
         this.nums=1;
        this.di="";
            }
        })
      },
      //判断他是否提交申请，提交了，就是待处理
      ordertuihuosstatus(){
        this.$axios.get('/api/Food/ordertuihuodingid?id='+this.userid).then(s=>{
            if (s.data!="") {
              console.log("sdadsadssd");
              console.log(s.data);
              if (s.data[0].Ordertuihuostatus=="已拒绝") {
                  this.nums=2;
        this.di="display: none;";
        this.dis="";
        this.sizes="商家已拒绝退货";
              }
              else{
              if (s.data[0].Ordertuihuostatus=="已完成") {
                  this.nums=3;
        this.di="display: none;";
         this.dis="display: none;";
              }
              else{
                 if (s.data[0].Ordertuihuostatus=="待处理") {
                  this.nums=2;
        this.di="display: none;";
        this.dis="";
              }
              else{
                 this.nums=1;
        this.di="";
        this.dis="display: none;";
              }
              }
            }}
        });
      }
  },
  created() {
    this.userid = this.$route.query.userids;
    this.orderlist();
    this.ordertuihuosstatus();
  },
};
</script>
<style scoped>
.chuli{
  font-size: 30px;
    height: 300px;
    text-align: center;
    position: relative;
    top: 130px;
}
/* CSS Document */
.refund-main{width: 100%;padding:0px 10px;}

/*进度条*/
.m-progress {margin: 0 auto 25px;height: 60px;max-width: 700px;margin-top:40px ;}
.m-progress-list{height: 66px;font-size: 0;text-align: justify;}
/*步骤背景*/
.m-progress-list .step {display: inline-block;width:70px;text-align: center;color: #999;letter-spacing: -5px;}
.m-progress-list .stage-name {padding-top: 10px;font-size: 12px;line-height: 14px;
letter-spacing: normal;word-spacing: normal;}
.u-progress-stage-bg {position: relative;display: inline-block;background-image: url(../../assets/images/sprite.png);
background-position: -45px -135px;width: 29px;height: 29px;}
/*变换的背景*/
.u-stage-icon-inner .bg {position: absolute;left: 0px;top: 0px;}
.step-1 .u-stage-icon-inner .bg {background-image: url(../../assets/images/sprite.png);background-position: -79px -135px;width: 19px;height: 19px;}
.step-3 .u-stage-icon-inner .bg {opacity:0;background-image: url(../../assets/images/sprite.png);background-position: -103px -135px;width: 19px;height: 19px;}

.u-stage-icon-inner {position: relative;z-index: 20;display: inline-block;width: 19px;height: 19px;line-height: 19px;
vertical-align: top;margin-top: 5px;margin-left: -24px;color: #b5b5b5;font-size: 12px;letter-spacing: normal;word-spacing: normal;}
.u-progress-placeholder {display: inline-block;width: 100%;height: 0;font-size: 0;line-height: 0;overflow: hidden;}


.u-progress-bar {margin: -56px 40px 0;background-color: #dcdcdc;height: 5px;font-size: 0;padding: 2px 0;}
.u-progress-bar-inner {position: relative;z-index: 10;height: 5px;width: 0;transition: width 1s .5s linear;background-color: #23c279;}



/*布局*/
.am-form-label {float: none;width: auto;font-size: 14px;font-weight: 600;margin: 10px auto;}
.am-form-content {margin-left: 0px;width:100% ;font-size: 14px;}
.am-form-content .am-selected,.am-form-content input{width: 100%;min-height:32px ;border:1px solid #e6e6e6;}
.am-form-content textarea {width: 100%;min-height:105px ;border:1px solid #e6e6e6; padding: 0.5em 0.7em;}
.info-btn{text-align: center;padding-bottom: 10px;}
.am-form-content li{font-size:14px ;}
.am-form-group {margin-bottom:0px;}
.am-form-group input{padding: 0.5em 0.7em;} 
.am-btn {border:none ;}
/*上传*/
.filePic {width:100px;padding:10px 10px;position: relative;overflow: hidden;}
.inputPic {cursor: pointer;opacity: 0;width: 100%;height: 100%;position: absolute;top: 0;left: 0;}
img{width:100% ;}
.refund-tip{position: relative;border:1px dashed #e6e6e6 ;margin:10px auto ;}
.refund-tip .desc{position: absolute;right:10px;top:45px ;}

.refund-aside{display:none ;padding: 10px;}
.am-form-group:after { content:"."; display:block; height:0; visibility:hidden; clear:both; }


/*钱款去向*/
.record-aside{display: none;}
.record-main .detail-list{padding:10px;border-bottom:1px solid #e6e6e6 ;overflow: hidden;}
.record-main .fund-tool{float: left;font-size:14px;}
.record-main .money{float:right;font-size:14px;}
.record-main .m-progress{margin-top:20px ;}

@media only screen and (min-width: 640px){
.comment-list{overflow: hidden;margin:0px auto;padding:0px 20px;}
.refund-main,.refund-aside{border:1px solid #e6e6e6;margin-bottom: 10px;}
/*布局*/
.am-form-label {float:left;width: auto;font-size: 14px;font-weight: 600;margin:7px auto;}
.am-form-content {margin-left:80px;width:auto;font-size: 14px;}
label span{display: none;}
.am-form-group{margin:10px 0px ;}

/*订单信息*/
.refund-aside{display:block;overflow: hidden;}
.item-pic{width:150px ;float:left;margin-right: 10px;}
.item-name{font-size: 14px;font-weight: 600;margin-bottom:5px ;}
.item-info{margin-top: 10px;}

/*钱款去向*/
.record-aside{display:block;}
.record-aside .item-pic{width: 100px;}
}
@media only screen and (min-width:1025px){
.refund-main,.refund-aside{float: left;}
.refund-main{width:70%;padding-right:60px ;}
.refund-aside{max-width:300px;width:30%;border-right: none;padding:15px;}
.item-title:after { content:"."; display:block; height:0; visibility:hidden; clear:both; }
.item-pic{width: 60px;}
.item-info div{margin: 5px auto;}
.item-info .info-title{width:80px ;display: inline-block;}

/*钱款去向*/
.record-aside {max-width:800px;margin: 10px auto;}
.record-aside .item-title:after {clear:none;}
.record-main{max-width: 900px;border:1px solid #eee ;margin: 0px auto;}

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
    width: 66px;
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
    /* margin-left: 180px; */
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