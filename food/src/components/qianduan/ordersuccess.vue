<template>
  <div>
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
                  <a href="#" target="_top" @click="security"
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
                  index="1"
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
        <div class="nav-extra">
          <i class="am-icon-user-secret am-icon-md nav-user"></i><b></b>我的福利
          <i class="am-icon-angle-right" style="padding-left: 10px"></i>
        </div>
      </div>
    </div>
    <b class="line"></b>
    <div class="take-delivery">
 <div class="status">
   <h2>您已成功付款</h2>
   <div class="successInfo" v-for="item in addresslist" :key="item.Addressid">
     <ul>
       <li>付款金额<em>¥{{usersum}}</em></li>
       <div class="user-info">
         <p>收货人：{{item.Addressname}}</p>
         <p>联系电话：{{item.Addressphone}}</p>
         <p>收货地址：{{item.Addresssuozaidiqu}}{{item.Addressxiangxidiqu}}</p>
       </div>
             请认真核对您的收货信息，如有错误请联系客服
                               
     </ul>
     <div class="option">
     </div>
    </div>
  </div>
</div>
  </div>
</template>

<script>
export default {
data(){
return{
    //获取收货地址的id
    addressid:"",
    addresslist:[]
    ,
    //获取用户的id
    usid:"",
    //获取用实付的总金额
    usersum:""
}
},
methods:{
        //跳转用户安全
  usersafety(){
   this.$router.push({
                path: "/qianduan/usersafety",
                query: {
                  userids: this.usid,
                },
              });
  },
  //跳转到用户信息
  security(){
       this.$router.push({
                path: "/qianduan/security",
                query: {
                  userids: this.usid,
                },
              });
  },
  //跳转到收货地址
  userdizhi(){
 this.$router.push({
                path: "/qianduan/userdizhi",
                query: {
                  userids: this.usid,
                },
              });
  },
  //跳转到收藏夹
  usershouchang(){
    this.$router.push({
                path: "/qianduan/shouchang",
                query: {
                  userids: this.usid,
                },
              });
  },
  //跳转到购物车
  goodshopp(){
        this.$router.push({
                path: "/qianduan/shopgowuche",
                query: {
                  userids: this.usid,
                },
              });
    },
    //跳转到收藏夹
  goodfoot(){
        this.$router.push({
                path: "/qianduan/shouchang",
                query: {
                  userids: this.usid,
                },
              });
    },
    //退出
    tui() {
      window.sessionStorage.clear();
      this.$router.push("/Login");
    },
    //根据收货id查询所有的数据
    getadrress(){
        this.$axios.get('/api/Food/addressesids?id='+this.addressid).then(s=>{
          this.addresslist=s.data;
          console.log(this.addresslist);
        })
    }
},
created(){
    this.addressid=this.$route.query.addressids;
      this.usid=this.$route.query.userid;
      this.usersum=this.$route.query.sum;
    console.log(this.addressid);
    this.getadrress();
}
}
</script>

<style scoped>
@charset "utf-8";
/* CSS Document */
h2, #success-pay h2 {font-size: 14px;height: 40px;line-height: 40px;margin-top:0px;}
.successInfo {display: inline-block;margin-left: -46px;padding:5px 0px;max-width: 547px;}
.successInfo em{color:#f00; font-weight:700; margin-left:5px;}
.take-delivery li {line-height: 28px;height:28px;}

.status .option { margin: 13px 0 25px 0px;}
.status .option .info {margin-right: 10px;}

.successInfo a span{font-size: 13px; margin: 0 10px 0 10px;color: #f00;}
.take-delivery {background: url(../../assets/images/T13iv.XiFdXXa94Hfd-32-32.png) no-repeat scroll 10px 30px transparent;padding: 27px 0 27px 60px;color: #333;
width:100% ;max-width:1000px;margin:0px auto;margin-top: 50px;}

.successInfo li{font-size:18px;}
.footer{max-width:1000px; margin:0px auto; margin-top:10px;}
.user-info p{ font-size:14px; padding:3px 0px;margin:0px 0px ;}

 @media only screen and (min-width:640px) 
{
.take-delivery{background: url(../../assets/images/T13iv.XiFdXXa94Hfd-32-32.png) no-repeat scroll 30px 30px transparent;padding: 27px 0 27px 76px;border: 1px solid #e5e5e5;margin-top: 10px;border: none;}
.user-info{border:1px solid #F00}
.successInfo {padding: 0 65px 0 56px;}
.user-info p{ font-size:14px; padding:10px;}

}



</style>