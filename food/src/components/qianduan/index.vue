<template>
  <div class="indexsd">
    <div class="hmtop">
      <!--顶部导航条 -->
      <div class="am-container header">
        <ul class="message-l">
          <div class="topMessage">
            <div class="menu-hd" v-show="zhu()">
              <a href="#" target="_top" class="h">亲，请登录</a>
              <a href="#" target="_top">免费注册</a>
            </div>
          </div>
        </ul>
        <ul class="message-r">
          <div class="topMessage home">
            <div class="menu-hd">
              <a href="#" target="_top" class="h" @click="s">商城首页</a>
            </div>
          </div>
          <div class="topMessage my-shangcheng">
            <div class="menu-hd MyShangcheng">
              <a href="#" @click="goodusers" target="_top"
                ><i class="am-icon-user am-icon-fw"></i>个人中心</a
              >
            </div>
          </div>
          <div class="topMessage mini-cart">
            <div class="menu-hd">
              <a id="mc-menu-hd" href="#" target="_top" @click="goodshopp">
                <i class="am-icon-shopping-cart am-icon-fw"></i
                ><span>购物车</span
                ><strong id="J_MiniCartNum" class="h"></strong></a
              >
            </div>
          </div>
          <div class="topMessage favorite">
            <div class="menu-hd">
              <a href="#" target="_top" @click="goodfoot"
                ><i class="am-icon-heart am-icon-fw"></i> <span>收藏夹</span></a
              >
            </div>
          </div>
          <div class="topMessage favorite" >
            <div class="menu-hd" >
              <a href="#" target="_top"
                ><span @click="tui" v-show="zhus()">退出</span></a
              >
            </div>
          </div>
        </ul>
      </div>

      <!--悬浮搜索框-->

      <div class="nav white">
        <div class="logo"><img src="../../assets/images/logo.png" /></div>
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
              index="1"
              type="submit" @click="shuosuo"
            />
          </form>
        </div>
      </div>

      <div class="clear"></div>
    </div>
    <div class="banner">
                      <!--轮播 -->
					<div
      class="imgBox"
      ref="imgBox"
      @mouseenter="stopSetInter"
      @mouseleave="startSetInter"
    >
      <a target="_blank" :href="imgList[now].url"><img :src="imgList[now].imgSrc" /></a> 
      <div class="btn-ion-left">
        <el-button @click="handlePre(preIndex)"
          ><i class="el-icon-arrow-left"></i
        ></el-button>
      </div>
      <div class="btn-ion-right">
        <el-button
          @click="handlePre(nextIndex)"
          icon="el-icon-arrow-right"
        ></el-button>
      </div>
      <div class="circle">
        <li
          v-for="(item, index) in imgList"
          :key="item.id"
          @click="handlePre(index)"
          class="box"
          :class="{ current: now == index }"
        ></li>
      </div>
    </div>
						<div class="clear"></div>	
			</div>
    <!-- 分类区域 -->
    <div class="shopNav">
      <div class="slideall">
        <div class="long-title"><span class="all-goods" style="color:white">全部分类</span></div>
        <div class="nav-cont">
          <ul>
            <li class="index"><a href="http://81.68.132.153:7070/">首页</a></li>
            <li class="qc"><a href="https://www.tmall.com/?spm=a21bo.21814703.201859.1.49fa11d9BdGwQk" target="_blank">天猫</a></li>
            <li class="qc"><a target="_blank" href="https://pages.tmall.com/wow/a/act/ju/dailygroup/2199/wupr?wh_pid=daily-222239&bid=3&spm=a21bo.21814703.201859.2.49fa11d9BdGwQk">聚划算</a></li>
            <li class="qc"><a target="_blank" href="https://chaoshi.tmall.com/?spm=a21bo.21814703.201859.3.49fa11d9BdGwQk">天猫超市</a></li>
            <li class="qc last"><a target="_blank" href="https://www.fliggy.com/?spm=a21bo.21814703.201859.5.49fa11d9BdGwQk">飞猪旅行</a></li>
          </ul>
        </div>
        <!--侧边导航 -->
        <div id="nav" class="navfull">
          <div class="area clearfix">
            <div class="category-content" id="guide_2">
              <div class="category">
                <ul class="category-list" id="js_climit_li">
                  <li class="appliance js_toggle relative first" v-for="(item,index) in typelist" :key="item.Goodtypetwoid" id="l">
                    <div class="category-info" @mouseover="m(item)" @mouseout="y(item)">
                      <h4 class="category-name b-category-name">
                       <a class="ml-22" :id="item" >{{item}}</a>
                      </h4>
                      <em>&gt;</em>
                    </div>
					<!-- 分类一级 -->
                    <div class="menu-item menu-in top" @mouseover="ms(item)" :style="fenlei">
                      <div class="area-in">
                        <div class="area-bg">
                          <div class="menu-srot">
                            <div class="sort-side">
                              <dl class="dl-sort">
                                <dt><span>{{fenleiname}}</span></dt>
                                <dd v-for="item1 in typename" :key="item1.Goodtypetwoid">
                                  <a href="#" @click="fenleidianj(item1.Goodtypeone.Goodtypeonename)"
                                    ><span>{{item1.Goodtypeone.Goodtypeonename}}</span></a
                                  >
                                </dd>
                              </dl>
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                    <b class="arrow"></b>
                  </li>
                </ul>
              </div>
            </div>
          </div>
        </div>
        <!--小导航 -->
        <div class="am-g am-g-fixed smallnav">
          <div class="am-u-sm-3">
            <a href="sort.html"
              ><img src="../../assets/images/navsmall.jpg" />
              <div class="title">商品分类</div>
            </a>
          </div>
          <div class="am-u-sm-3">
            <a href="#"
              ><img src="../../assets/images/huismall.jpg" />
              <div class="title">大聚惠</div>
            </a>
          </div>
          <div class="am-u-sm-3">
            <a href="#"
              ><img src="../../assets/images/mansmall.jpg" />
              <div class="title">个人中心</div>
            </a>
          </div>
          <div class="am-u-sm-3">
            <a href="#"
              ><img src="../../assets/images/moneysmall.jpg" />
              <div class="title">投资理财</div>
            </a>
          </div>
        </div>

        <!--走马灯 -->

        <div class="marqueen">
          <span class="marqueen-title">商城头条</span>
          <div class="demo">
            <ul>
              <li class="title-first">
                <a target="_blank" href="https://www.baidu.com/link?url=_-TEeVJ0eMrdNwej_Go7G1S-rDToCda0qaBSqyhCCt1wUiDckHLvWNqps74DCaCm4feY0R5vcCnCG1dVHAoyPa&wd=&eqid=f7b04ac5000861670000000560ef92b9">
                  <img src="../../assets/images/TJ2.jpg" />
                  <span>[特惠]</span>商城爆品1分秒
                </a>
              </li>
              <li class="title-first">
                <a target="_blank" href="http://ysj.yhopt.com/HotSale/ArticleShow.aspx?AID=67">
                  <span>[公告]</span>商城与广州市签署战略合作协议
                  <img src="../../assets/images/TJ.jpg" />
                  <p>XXXXXXXXXXXXXXXXXX</p></a
                >
              </li>
              <div class="mod-vip">
                <div class="m-baseinfo">
                  <a href="#">
                    <img src="../../assets/images/getAvatar.do.jpg" />
                  </a>
                  <em>
                    Hi,<span class="s-name">{{ name }}</span>
                  </em>
                </div>
                <div class="member-logout" v-show="zhu()">
                  <a
                    class="am-btn-warning btn"
                    href="#" @click="dengliu"
                    >登录</a
                  >
                  <a
                    class="am-btn-warning btn"
                    href="#" @click="zhuches"
                    >注册</a
                  >
                </div>
                <div class="member-login">
                  <a href="#"><strong>0</strong>待收货</a>
                  <a href="#"><strong>0</strong>待发货</a>
                  <a href="#"><strong>0</strong>待付款</a>
                  <a href="#"><strong>0</strong>待评价</a>
                </div>
                <div class="clear"></div>
              </div>
              <li>
                <a target="_blank" href="https://www.sohu.com/a/249122569_426303"
                  ><span>[特惠]</span>洋河年末大促，低至两件五折</a
                >
              </li>
              <li>
                <a target="_blank" href="https://www.jd.com/"
                  ><span>[公告]</span>华北、华中部分地区配送延迟</a
                >
              </li>
              <li>
                <a target="_blank" href="https://zhidao.baidu.com/question/432231973820854572.html"
                  ><span>[特惠]</span>家电狂欢千亿礼券 买1送1！</a
                >
              </li>
            </ul>
            <div class="advTip">
              <img src="../../assets/images/advTip.jpg" />
            </div>
          </div>
        </div>
        <div class="clear"></div>
      </div>
    </div>
    <!--今日推荐 -->
    <br>
				
    <div class="shopMainbg">
      <div class="shopMain" id="shopmain">
        <div class="am-g am-g-fixed recommendation">
						<div class="clock am-u-sm-3">
<img src="../../assets/images/day-to.png" />
							<p style="color:white">今日<br>推荐</p>
						</div>
						<div class="am-u-sm-4 am-u-lg-3" v-for="(itemsd,index) in goodlist" :key="itemsd.Goodid" @click="xiang(itemsd.GoodName)">
							<div class="info ">
								<h3  v-if="index<3">{{itemsd.GoodName}}</h3>
								<h4 v-if="index<3">开年福利篇</h4>
							</div>
							<div class="recommendationMain one" v-if="index<3">
								<a href="#" > <img :src="'http://81.68.132.153:7070/img/'+itemsd.GoodImage" alt=""></a>
							</div>
						</div>
					</div>
        <div class="clear"></div>
        <br>
        <div class="body-3">
            <h1 class="title-h1">
                <div class="icon"></div>猜你喜欢
            </h1>
            <div class="content">
                <div class="item" v-for="(itemsd,index) in goodlist" :key="itemsd.Goodid" @click="xiang(itemsd.GoodName)">
                    <img v-if="index<=9" :src="'http://81.68.132.153:7070/img/'+itemsd.GoodImage" alt="">
                    <p class="desc-1" v-if="index<11">{{itemsd.GoodName}}</p>
                    
                    <p></p>
                </div>

            </div>
        </div>

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
    </div>
    <!--引导 -->
    <div class="navCir">
      <li class="active">
        <a href="home.html"><i class="am-icon-home"></i>首页</a>
      </li>
      <li>
        <a href="sort.html"><i class="am-icon-list"></i>分类</a>
      </li>
      <li>
        <a href="shopcart.html"
          ><i class="am-icon-shopping-basket"></i>购物车</a
        >
      </li>
      <li>
        <a href="person/index.html"><i class="am-icon-user"></i>我的</a>
      </li>
    </div>
    <!--菜单 -->
			<div class=tip>
				<div id="sidebar" style="background-color: white;">
					<div id="wrap">
						
						<div class="quick_toggle">
							
							<li class="qtitem">
								<a href="#top" class="return_top"><span class="top"></span></a>
							</li>
						</div>
						<!--回到顶部 -->
						<div id="quick_links_pop" class="quick_links_pop hide"></div>
					</div>
				</div>
				
			</div>
  </div>
</template>

<style scoped>
@import "../../assets/AmazeUI-2.4.2/assets/css/admin.css";
@import "../../assets/AmazeUI-2.4.2/assets/css/amazeui.css";
@import "../../assets/css/hmstyle.css";
@import "../../assets/basic/css/demo.css";
@import "../../assets/css/skin.css";
@import "../../assets/css/index.css";
.indexsd{
  background-color: white;
}
.item:hover, .quick_toggle li:hover {
   background: none; 
}
.imgBox {
  width: 800px;
  height: 423px;
  margin: 6px 318px;
  position: relative;
}
.imgBox img {
  width: 100%;
  height: 100%;
}
.btn-ion-left {
  width: 100px;
  position: absolute;
  top: 50%;
  left: 0;
  opacity: 0.7;
}
.btn-ion-right {
  width: 100px;
  position: absolute;
  top: 50%;
  right: 0;
  opacity: 0.7;
}
.circle {
  width: 100px;
  height: 20px;
  display: flex;
  position: absolute;
  bottom: 10px;
  left: 50%;
  transform: translateX(-50%);
}
.current {
  background-color: #fff !important;
}
.box {
  list-style: none;
  width: 10px;
  height: 10px;
  border-radius: 50%;
  background-color: #000;
  opacity: 0.7;
  margin: 0 10px;
}
</style>
<script>
import $ from "jquery";
// import '../../assets/AmazeUI-2.4.2/assets/js/jquery.min.js';
// import '../../assets/AmazeUI-2.4.2/assets/js/amazeui.min.js';
// import '../../assets/basic/js/quick_links.js';
//轮播
$(function () {
  $(".am-slider").flexslider();
  $("li").hover(
    function () {
      $(".category-content .category-list li.first .menu-in").css(
        "display",
        "none"
      );
      $(".category-content .category-list li.first").removeClass("hover");
      $(this).addClass("hover");
      $(this).children("div.menu-in").css("display", "block");
    },
    function () {
      $(this).removeClass("hover");
      $(this).children("div.menu-in").css("display", "none");
    }
  );
  //参数是函数名
  //   window.location.reload(1);
});
export default {
  data() {
    return {
		//接收用户名
      name: "",
      //接收商品分类数据
     typelist:[],
	typename:[],
  sname:"",
  goodlist:[],
  imgList: [
        {
          imgSrc: require("../../assets/images/ad4.jpg"),
          id: 1,
          url:"https://s.taobao.com/search?q=%E8%82%89%E7%B1%BB&imgfile=&js=1&stats_click=search_radio_all%3A1&initiative_id=staobaoz_20210625&ie=utf8"
        },
        {
          imgSrc: require("../../assets/images/ad2.jpg"),
          id: 2,
          url:"https://www.uueat.com/"
        },
        {
          imgSrc: require("../../assets/images/ad3.jpg"),
          id: 3,
          url:"https://yp.jd.com/"
        },
      ],
      now: 0, // 图片的索引
      Interval: "", // 定时器
      //用户id
      userids:"",
      fenlei:"",
      fenleiname:""
    };
  },
  methods: {
    dd() {},
	//判断有没有登录
    zhu() {
      if (this.name != null) {
        return false;
      }
      return true;
    },
    getgoodlist(){
      this.$axios.get('/api/Food/goods').then(s=>{
         this.goodlist=s.data;
		});
    }
    ,
	//查询所有商品分类
	gettypelist(){
		this.$axios.get('/api/Food/goodtypetwos').then(s=>{
         this.typelist=s.data;
		this.typelist.reverse();
		});
	},
	//根据分类名
	getnamelist(){
		this.$axios.get('/api/Food/goodtypetwonames?name='+this.sname).then(s=>{
         this.typename=s.data;
         console.log(this.typename)
		});
	},
  ms(sender){
   this.fenlei="display: block;";
  },
	m(sender){
    this.fenlei="display: block;";
    this.sname=sender;
    this.fenleiname=sender;
    this.getnamelist();
		// console.log($(sender).children('category-info').children("category-name").children("ml-22").prevObject[0].fromElement.innerText)
		// let id=sender.children('a')
		// // console.log(id)
    // var lin=document.getElementById("l").childNodes[0];
    // console.log(lin);
	},
  y(sender){
     this.fenlei="display: none;";
        this.sname=sender;
          this.fenleiname=sender;
    this.getnamelist();
  },
  //退出
  tui(){
     window.sessionStorage.clear();
     this.$router.push("/Login");
  },
  //商品详情页面
  xiang(sender){
    window.sessionStorage.getItem("token",this.name)
     this.$router.push({
          path: '/qianduan/shopping',
          query: {
            ids: sender,
            namess: this.name
          }
        });
  },
  zhus() {
      if (this.name != null) {
        return true;
      }
      return false;
    },
    // 鼠标进入时会自动播放轮播图
    stopSetInter() {
        clearInterval(this.Interval) // 清除定时器
    },
    // 鼠标离开则不会自动轮播 
    startSetInter(){
        this.MyInterval()
    },
    MyInterval() {
        var i = 0
        this.Interval = setInterval(() => {
            this.handlePre(this.nextIndex)
        }, 2000)
    },
    handlePre(preIndex) {
        // console.log(this.now)
        this.now = preIndex
    },
    //跳转到购物车
    goodshopp(){
       if (this.name == null) {
        this.$router.push('/Login');
      } else {
        console.log();
         this.$axios.get('/api/Food/foodUsersname?name='+this.name).then(sd=>{
            if (sd.data!="") {
             this.userids=sd.data[0].Userxixid;
             this.$router.push({
              path: '/qianduan/shopgowuche',
              query: {
                userids:this.userids
              }
      });
            }else{
              this.$message.error("查询用户失败!");
            }
          })
      }
    },
    //跳转到个人中心
    goodusers(){
       if (this.name == null) {
        this.$router.push('/Login');
      } else {
        console.log();
         this.$axios.get('/api/Food/foodUsersname?name='+this.name).then(sd=>{
            if (sd.data!="") {
             this.userids=sd.data[0].Userxixid;
             this.$router.push({
              path: '/qianduan/Information',
              query: {
                userids:this.userids
              }
      });
            }else{
              this.$message.error("查询用户失败!");
            }
          })
      }
    },
    //跳到搜索页面
    shuosuo(){
       this.$router.push({
          path: '/qianduan/search',
          query: {
            namess: this.name
          }
        });
            //  this.$router.push('/qianduan/search');
    },
    //跳转到收藏夹
    goodfoot(){
 if (this.name == null) {
        this.$router.push('/Login');
      } else {
        console.log();
        
         this.$axios.get('/api/Food/foodUsersname?name='+this.name).then(sd=>{
            if (sd.data!="") {
              
             this.userids=sd.data[0].Userxixid;
             this.$router.push({
              path: '/qianduan/shouchang',
              query: {
                userids:this.userids
              }
      });
      
            }else{
              this.$message.error("查询用户失败!");
            }
          })
      }
    },
    s(){
			window.location.reload();
		},
    fenleidianj(sender){
       this.$router.push({
          path: '/qianduan/search',
          query: {
            onename:this.fenleiname,
            namess: this.namess
          }
        });
    },
    dengliu(){
      this.$router.push('/Login');
    },
    zhuches(){
      this.$router.push('/register');
    }
  },
  computed: { // 计算属性
    preIndex() {
      if(this.now == 0) {
        return this.imgList.length - 1
      }else {
        return this.now -1
      }
    },
    nextIndex() {
      if(this.now == this.imgList.length-1) {
        return 0
      }else {
        return this.now + 1
      }
    }
  },
  created() {
	this.gettypelist();
  this.getgoodlist();
    const tokenstr = window.sessionStorage.getItem("token");
    this.name = tokenstr;
    // alert(tokenstr)
    console.log(this.name);
  let s= this.$session.get("key"); 
    console.log(s);

  },
};
</script>
