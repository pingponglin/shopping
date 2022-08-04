<template>
  <el-container class="Admin-container">
    <!-- 头部区域 -->
  <el-header>
      <div class="d">
          <img src="http://81.68.132.153:7070/img/1s.png" width="63" style="width:63px" height="63" alt="">
          <span class="Admin-sp" style="font-size: 17px">食品零售系统</span><i class="el-icon-s-unfold" style="position: relative;left: 20px;" @click="z"></i>
      </div>
      <!-- <span style="margin-left: 1100px;line-height: 61px;">{{name}}</span> -->
      <el-badge :value="xiaoxi" style="position: relative;left: 1168px;top: 22px;">
  <button style="background:none;border: none;padding: 0px 0px;font-size: 21px;" @click="drawer = true" class="el-icon-bell"></button>
</el-badge>
      <el-popover placement="bottom" width="100" trigger="click">
         <div style="text-align:center">
         <p style="margin-top:-10px"><span v-on:click="tui">退出</span></p>
         </div>
    <el-avatar src="http://81.68.132.153:7070/img/头像.jpg" slot="reference" style="margin-left: 1190px;margin-top: 11px;"></el-avatar>
  </el-popover>
     <span style="line-height: 61px;">{{name}}</span>
  </el-header>
  <!-- 页面主体区域 -->
  <el-container>
      <!-- 侧边栏 -->
    <el-aside :width="isCollapse?'64px':'200px'" class="els">
        <!-- 侧边栏菜单区域 -->
        <el-menu
      background-color="#333744"
      text-color="#fff"
      active-text-color="#409EFF" :unique-opened="true" :collapse="isCollapse" :router="true" :collapse-transition="false">
      <!-- 一级菜单 -->
      <el-submenu index="1">
          <!-- 一级菜单模板区域 -->
        <template slot="title">
          <i class="iconfont icon-icon_user"></i>
          <span> 用户管理</span>
        </template>
        <!-- 二级菜单 -->
          <el-menu-item index="/admins">
                <template slot="title">
          <i class="el-icon-menu"></i>
          <span>用户列表</span>
        </template>
          </el-menu-item>
      </el-submenu>
      <el-submenu index="2">
          <!-- 一级菜单模板区域 -->
        <template slot="title">
          <i class="iconfont icon-shangpin"></i>
          <span>商品管理</span>
        </template>
        <!-- 二级菜单 -->
          <el-menu-item index="/goodsliebiao">
                <template slot="title">
          <i class="el-icon-menu"></i>
          <span>商品列表</span>
        </template>
          </el-menu-item>
           <el-menu-item index="/goods/kowei">
                <template slot="title">
          <i class="el-icon-menu"></i>
          <span>商品口味</span>
        </template>
          </el-menu-item>
          <el-menu-item index="/goods/Param">
                <template slot="title">
          <i class="el-icon-menu"></i>
          <span>商品参数</span>
        </template>
          </el-menu-item>
          <el-menu-item index="/goods/goodtypeone">
                <template slot="title">
          <i class="el-icon-menu"></i>
          <span>商品一级分类</span>
        </template>
          </el-menu-item>
           <el-menu-item index="/goods/goodtype">
                <template slot="title">
          <i class="el-icon-menu"></i>
          <span>商品二级分类</span>
        </template>
          </el-menu-item>
      </el-submenu>
      <el-submenu index="3">
          <!-- 一级菜单模板区域 -->
        <template slot="title">
          <i class="iconfont icon-danju"></i>
          <span>订单管理</span>
        </template>
        <!-- 二级菜单 -->
          <el-menu-item index="/order/order">
                <template slot="title">
          <i class="el-icon-menu"></i>
          <span>订单列表</span>
        </template>
          </el-menu-item>
          <el-menu-item index="/order/ordertuihuo">
                <template slot="title">
          <i class="el-icon-menu"></i>
          <span>退货列表</span>
        </template>
          </el-menu-item>
          <!-- <el-menu-item index="1-7">
                <template slot="title">
          <i class="el-icon-menu"></i>
          <span>评价列表</span>
        </template>
          </el-menu-item> -->
      </el-submenu>
    </el-menu>
    </el-aside>
    <!-- 右侧内容主体 -->
    <el-main>
      <!-- 路由占位符 -->
      <!-- <sidebar /> -->
      <router-view></router-view>
    </el-main>
<el-drawer
  title="我是标题"
  :visible.sync="drawer"
  :with-header="false">
  <div>
    <p style="text-align: center;font-weight: bold;font-size: 24px;margin-top: 16px;">用户提醒未发货的订单</p>
 <div class="tang" v-for="items in xiaoxilist" :key="items.Orderid">
   <el-row>
  <el-col :span="4"><div>订单编号</div></el-col>
  <el-col :span="6"><div>订单数量</div></el-col>
  <el-col :span="4"><div>订单金额</div></el-col>
  <el-col :span="10"><div>操作</div></el-col>
</el-row>
<el-row>
  <el-col :span="4"><div style="word-wrap:break-word;width: 100px;">{{items.Ordername}}</div></el-col>
  <el-col :span="6"><div>{{items.Ordernum}}</div></el-col>
  <el-col :span="4"><div>{{items.Ordersum}}</div></el-col>
  <el-col :span="10"><div>
    <el-button size="mini" type="primary" style="background-color: #409EFF;color:white;border:none;" 
    @click="orderding(items.Orderid)">查看订单</el-button>
    <el-button size="mini" type="success" style="background-color: #67C23A;color:white;border:none;" 
     @click="faInfo(items.Orderid)" >发货</el-button>
    </div></el-col>
</el-row>
</div></div>
</el-drawer>
  </el-container>
</el-container>
</template>

<script>
export default {
data(){
  return{
  name:"",
   isCollapse: false,
   //消息
   xiaoxi:"",
   //获取未发货的信息
   xiaoxilist:[]
   ,
   drawer: false,
   faform:{
     Orderid:""
   }
  }
},
created(){
  // this.name = this.$route.query.n;
  const tokenstr=window.sessionStorage.getItem('token');
    this.name = tokenstr;console.log(this.name);
    this.orderfahuo();
}
,
methods:{
    tui(){
      //清空token
      window.sessionStorage.clear();
     this.$router.push("/Login");
    },
    z(){
      this.isCollapse=!this.isCollapse;
    },
    //查询所有用户提醒未发货的信息
    orderfahuo(){
      this.$axios.get('/api/Food/ordertixi').then(s=>{
        if (s.data!="") {
          this.xiaoxi=s.data.length;
          this.xiaoxilist=s.data;
        }
      })
    },
    //跳到订单详情
    orderding(id){
      this.drawer=false;
this.$router.push({
          path: '/order/orderding',
          query: {
            ids: id
          }
        })
    },
    //发货
    faInfo(id) {
      this.faVisible = true;
     this.$axios.get("/api/Food/orderfahuoslin?id="+id).then((d) => {
        if (d.data == "发货成功") {
          this.orderfahuo();
          this.$message.success("发货成功!");
        } else {
          this.$message.error("发货失败!");
        }
      });
    }
}
}
</script>

<style  scoped>
.tang{
  text-align: center;
  border: 1px solid gainsboro;
  margin-top: 29px;
  margin-left: 15px;
  width: 435px;
}
.el-button--small, .el-button--small.is-round {
    padding: 9px 15px;
}

.el-button--mini, .el-button--small {
    font-size: 12px;
    border-radius: 3px;
}
.el-button {
    display: inline-block;
    line-height: 1;
    white-space: nowrap;
    cursor: pointer;
    background: #FFF;
    border: 1px solid #DCDFE6;
    color: #606266;
    -webkit-appearance: none;
    text-align: center;
    box-sizing: border-box;
    outline: 0;
    margin: 0;
    transition: .1s;
    font-weight: 500;
    padding: 12px 20px;
    font-size: 14px;
    border-radius: 4px;
}
.el-button, .el-checkbox {
    -webkit-user-select: none;
    -moz-user-select: none;
    -ms-user-select: none;
}
</style>
<style scoped>
@import '../../src/assets/fonts/iconfont.css';
.Admin-container{
    height: 100vh;
}
.el-header{
    background-color: #373d41;
    display: flex;
    justify-content: space-between;
    padding-left: 0;
    color: #fff;
    font-size: 20px;
}
.d{
    display: flex;
    align-items: center;
}
.Admin-sp{
     margin-left: 15px;
}
.el-aside{
    background-color: #333744;
}
.el-main{
    background-color: #EAEDF1;
}
.el-menu{
  border-right: none;
}
.els{
  transition: linear 0.3s;
}
.item {
  margin-top: 10px;
  margin-right: 40px;
}
</style>
