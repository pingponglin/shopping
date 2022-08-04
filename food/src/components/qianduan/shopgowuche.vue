<template>
  <div>
      <!--顶部导航条 -->
      <div class="am-container header">
        <!-- <ul class="message-l">
          <div class="topMessage">
            <div class="menu-hd" v-show="zhu()">
              <a href="#" target="_top" class="h">亲，请登录</a>
              <a href="#" target="_top">免费注册</a>
            </div>
          </div>
        </ul> -->
        <ul class="message-r">
          <div class="topMessage home">
            <div class="menu-hd">
              <a href="#" target="_top" class="h" @click="s">商城首页</a>
            </div>
          </div>
          <div class="topMessage my-shangcheng">
            <div class="menu-hd MyShangcheng">
              <a href="#" target="_top" @click="goodusers"
                ><i class="am-icon-user am-icon-fw"></i>个人中心</a
              >
            </div>
          </div>
          <div class="topMessage mini-cart">
            <div class="menu-hd">
              <a id="mc-menu-hd" :href="'http://81.68.132.153:7070/qianduan/shopgowuche?userids='+this.userid" target="_top">
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
              type="submit"
            />
          </form>
        </div>
      </div>

      <div class="clear"></div>
       <div id="shop_car">
    <section class="car_main">
      <!--顶部列表-->
      <div class="car_head">
        <ul class="car_top">
          <li class="car_check_all">
            <input type="checkbox" id="check_all" v-model="checked_all" @click="all_products_checked"/>
            <label for="check_all">全选</label>
          </li>
          <li class="car_information">商品信息</li>
          <li class="car_price">单价</li>
          <li class="car_number">数量</li>
          <li class="car_amount">金额</li>
          <li class="car_operation">操作</li>
        </ul>
      </div>
      <!--购物车为空时展示页面-->
      <template v-if="goods.length ==  0">
        <div class="cart_empty">
          您的购物车还是空的哦，快去挑选您喜欢的东西吧.
        </div>
      </template>
      <!--购物车详情展示-->
      <template v-else>
        <div v-for="(shop,shop_index) in goods" :key="shop">

          <!--当店铺下面有已购买商品的时候显示该店铺和商品信息-->
          <div v-if="shop.list.length != 0">
            <div v-for="(product,product_index) in shop.list" class="product"
                 v-bind:class="[product.shoppcheck ? 'selected_styles' : '']" :key="product.shoppingid">
              <div class="product_details">

                <!--商品是否选中-->
                <div class="product_check">
                  <input type="checkbox" v-model="product.shoppcheck"
                         @click="product_checked_click(shop_index,product_index)"/>
                </div>

                <!--商品图片-->
                <div class="product_img">
                  <img :src="'http://81.68.132.153:7070/img/'+product.Good.GoodImage" style="width: 100px;height: 100px"/>
                </div>

                <!--商品名称-->
                <div class="product_shop_info">
                  <div class="product_shop_name">
                    <a :href="product.href">{{product.Good.GoodName}}</a>
                  </div>

                  <div class="product_shop_icon">
                    <!-- <img src="../../static/ShopCar/xcard.png" title="银联支付"/>
                    <img src="../../static/ShopCar/7day.png" title="7天内无条件退换"/>
                    <img src="../../static/ShopCar/wuyou.png" title="消费者保障服务，商家承若如实描述"/> -->
                  </div>
                </div>

                <!--商品尺寸颜色等属性-->
                <div class="product_type_select">
                  <div class="product_type_all">
                    <div class="product_type">
                       <span>{{product.Goodkowei.Goodkoweiname}}</span>
                    </div>
                  </div>
                  
                </div>

                <!-- //商品价格 -->
                <div class="product_price">
                  <div v-if="product.Good.GoodPrice" class="product_price_origin">
                    ￥{{product.Good.GoodPrice | priceFilter}}
                  </div>
                  <div class="product_price_current">
                    ￥{{product.Good.GoodPrcieper | priceFilter}}
                  </div>
                </div>

                <!--商品数量-->
                <div class="product_number">
                  <div class="product_number_content">
                    <div class="product_number_button">
                      <button v-if="product.shoppingnum > 1" @click="product_reduce(shop_index,product_index)">-</button>
                    </div>
                    <div class="product_number_input">
                      <input type="number" v-model="product.shoppingnum"  readonly/>
                    </div>
                    <div class="product_number_button" @click="product_add(shop_index,product_index)">
                      <button>+</button>
                    </div>
                  </div>
                </div>

                <!--金额统计-->
                <div class="product_amount">
                  <div class="product_total_price">￥{{ product_total_price(shop_index,product_index) | priceFilter}}
                  </div>
                </div>

                <!--操作选项-->
                <div class="product_operation">
                  <div>
                    <button @click="getfootpring(product.Goodid)">移入收藏夹</button>
                  </div>
                  <div>
                    <button @click="product_del(product.shoppingid)">删除</button>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </template>
      <!--底部页面-->
      <div class="car_foot_bar">
        <div class="car_foot_settle">
          <div class="piece">已选商品 <strong class="piece_num">{{selected_products}}</strong> 件</div>
          <div class="totalMoney">合计 (不含运费) : <strong class="total_text">{{total_amount | priceFilter}}</strong> 元</div>
          <div class="settle_accounts">
            <button class="settle_button" :disabled="selected_products == 0 ? true : false" @click="shop_settle">
              买单
            </button>
          </div>
        </div>
      </div>
    </section>
  </div>
  </div>
</template>

<script>
export default {
    name: 'VShopCar',
    data() {
      return {
         //接受商品名称
      names: "",
	//判断用户有没有登录
	namess:"" 
          ,
          //接收根据用户查询所有商品
          goodname:[],
          //接收商品口味名称查询所有商品
          goodkouweis:"",
          //接收口味名称
          kowd:""
          ,
          //接收所有口味名称
          kowslist:[]
          ,
          //用户id
          userid:"",
        goods: [
          {
            list: [
            ]
          }
        ],
        // 其他属性数据
        checked_all: false,
        num:"",
        //接收添加收藏的数据
        footpring:{
           Goodid:0,footprintdate:"",Userxixid:0
        },
        //接收商品口味id
        kowid:[],
        //获取选中的商品数量
        goodnums:[]
      }
    },

    methods: {
 //退出
  tui(){
     window.sessionStorage.clear();
     this.$router.push("/Login");
  },
  //判断有没有登录
   zhus() {
      if (this.namess != null) {
        return true;
      }
      return false;
    },
      // 结算
      shop_settle() {
        this.$router.push({
                      path: "/qianduan/pay",
                      query: {
                        shoppid: this.userid,
                        shoppidkowid:this.kowid,
                        shoppidgoodnums:this.goodnums
                      },
                    });
      },
      // 商品总价
      product_total_price(shop_index, product_index) {
        var product = this.goods[shop_index].list[product_index]
        return product.shoppingnum * product.Good.GoodPrcieper
      },
      // 减购商品，每次减少1
      product_reduce(shop_index, product_index) {
        var product = this.goods[shop_index].list[product_index]
        if ((product.shoppingnum - 1)) {
          product.shoppingnum--
        }
      },
      // 加购，每次加1
      product_add(shop_index, product_index) {
        var product = this.goods[shop_index].list[product_index]
        if ((product.shoppingnum + 1) < 100) {
          product.shoppingnum++
        }
      },
      // 删除购买商品
      product_del(sender) {
       this.$axios.get('/api/Food/shoppingDelete?id='+sender).then(s=>{
         if (s.data=="删除成功") {
           this.$message.success("删除成功");
           this.getGoods();
         }
         else{
           this.$message.error("删除失败!");
         }
       })
        // this.goods[shop_index].list.splice(product_index, 1)
      },
      // 店铺下属商品全部选择时
      shop_all_check(shop_index) {
        var shop = this.goods[shop_index]
        shop.all_checked = !shop.all_checked
        for (var i = 0; i < shop.list.length; i++) {
          shop.list[i].shoppcheck = shop.all_checked;
        }
      },
      // 商品选择时
      product_checked_click(shop_index, product_index) {
        var product = this.goods[shop_index].list[product_index]
        product.shoppcheck = !product.shoppcheck;
        this.kowid.push(product.Goodkowei.Goodkoweiid);
        this.goodnums.push(product.shoppingnum);
        console.log("sssss");
        console.log(this.kowid);
        console.log(this.goodnums);
        // 检测是否该店铺内的商品全选
        for (var i = 0; i < this.goods[shop_index].list.length; i++) {
          if (!this.goods[shop_index].list[i].shoppcheck) {
            this.goods[shop_index].all_checked = false
            this.checked_all = false
            return;
          }
        }
        this.goods[shop_index].all_checked = true

        // 检测购物车内的商品是否全部选中
        for (let i = 0; i < this.goods.length; i++) {
          if (!this.goods[i].all_checked) {
            this.checked_all = false
           
            return
          } 
        }
        this.checked_all = true
      },
      // 检测购物车内的商品全部
      all_products_checked() {
        this.checked_all = !this.checked_all
        for (var i = 0; i < this.goods.length; i++) {
          this.goods[i].all_checked = this.checked_all
          for (var j = 0; j < this.goods[i].list.length; j++) {
            this.goods[i].list[j].shoppcheck = this.checked_all
            this.kowid.push(this.goods[i].list[j].Goodkowei.Goodkoweiid);
            this.goodnums.push(this.goods[i].list[j].shoppingnum);
            console.log(this.goodnums)
            //  this.goodnums=this.goods[i].list[j].shoppingnum;
          }
        }
      }
      ,
      //查询所有购物车
      getgoodlist(){
          this.$axios.get('/api/Food/shoppings').then(s=>{
              // this.goods[0].list=s.data;
              // console.log(s.data);
              // console.log(this.goods[0].list);
          })
      },
      //根据用户id查询商品所有
      getGoods(){
        this.$axios.get('/api/Food/shoppingid?id='+this.userid).then(d=>{
          if (d.data!="") {
          this.goods[0].list=d.data;
          console.log(this.goods[0].list);
          }
        })
      },
      xiang(sender){
          // if (sender.Goodkowei.Goodkoweiname1==this.kowd) {
            
          // }
      },
      s(){
			this.$router.push("/");
		},
    //点击移入收藏夹
    getfootpring(senders){
      var goodids=senders;
       this.footpring.Goodid=goodids;
       this.footpring.Userxixid=this.userid;
      this.$axios.post('/api/Food/footprintADD',this.footpring).then(s=>{
         if (s.data=="添加成功") {
           var l= this.goods[0].list[0].shoppingid;
           this.$axios.get('/api/Food/shoppingDelete?id='+l).then(d=>{
             if (d.data=="删除成功") {
               window.location.reload();
               this.$message({
          message: '移入收藏夹成功',
          type: 'success'
        });
             }
           })
            
         }
         else{
 this.$message.error('移入收藏夹失败');
         }
      })
    },
    goodusers(){
             this.$router.push({
              path: '/qianduan/Information',
              query: {
                userids:this.userid
              }
             })
    },
    goodfoot(){
  this.$router.push({
              path: '/qianduan/shouchang',
              query: {
                userids:this.userid
              }
             })
    }
    },
    filters: {
      // 金额显示过滤 两位小数点，不足补0
      priceFilter(value) {
        var values = Math.round(parseFloat(value) * 100) / 100;
        var xsd = value.toString().split(".");
        if (xsd.length == 1) {
          values= value.toString() + ".00";
          return values;
        }
        if (xsd.length > 1) {
          if (xsd[1].length < 2) {
            values = value.toString() + "0";
          }
          return values;
        }
      }
    },

    computed: {

      // 已选择商品数目
      selected_products() {
        var _this=this;
        var selected_products = 0
        for (var i = 0; i < this.goods.length; i++) {
          var product = this.goods[i].list
          for (var j = 0; j < product.length; j++) {
            if (product[j].shoppcheck) {
                // selected_products=product[i].shoppingnum++;
                  selected_products+=product[j].shoppingnum; 
            }
          }
          // selected_products=selected_products++;
        }
       
        return selected_products
      },

      // 购买商品总金额
      total_amount() {
        var total_price = 0.00
        for (var i = 0; i < this.goods.length; i++) {
          var product = this.goods[i].list
          for (var j = 0; j < product.length; j++)
            if (product[j].shoppcheck) {
              total_price += product[j].shoppingnum * product[j].Good.GoodPrcieper
            }
        }
        return total_price
      },

      // 购物车全选
      all_checked() {
        for (var i = 0; i < this.goods.length; i++) {
          if (!this.goods[i].all_checked) {
            return false
          }
        }
        return true
      }
    },
     created(){
    this.goodkouweis = this.$route.query.ids;
     this.kowd = this.$route.query.kowdi;
     var user= this.$route.query.userid;
    var userids= this.$route.query.userids;
    if (user!=null) {
      this.userid=user
    }
    if (userids!=null) {
      this.userid=userids
    }
     console.log(this.kowd);
      console.log(this.userid);
    console.log("this.goodkouweis");
    console.log(this.goodkouweis);
    // this.getgoodlist();
    this.getGoods();
    }
  }
</script>

<style scoped>

  .car_main {
    position: relative;
    width: 980px;
    margin: 0px auto;
    padding: 0px 0px;
    min-height: 250px;
  }

  .car_head {
    width: 100%;
    height: 45px;
    line-height: 45px;
    color: #3c3c3c;
    font-size: 14px;
    padding: 0px;
    border-bottom: 1px solid #DCDCDC;
  }

  .car_top {
    width: 100%;
    height: 50px;
  }

  ul {
    list-style: none;
  }

  li {
    float: left;
    text-align: left;
  }

  .car_check_all {
    position: relative;
    width: 10%;
    left: -20px;
  }

  .car_check_all input[type="checkbox"] {
  }

  .car_check_all label {
  }

  .car_information {
    width: 45%;
  }

  .car_price {
    width: 11%;
  }

  .car_number {
    width: 10%;
  }

  .car_amount {
    width: 11%;
  }

  .cart_empty {
    position: absolute;
    width: 100%;
    top: 50%;
    text-align: center;
  }

  .car_foot_bar {
    position: absolute;
    width: 100%;
    height: 45px;
    font-size: 14px;
    color: #3c3c3c;
    margin-top: 15px;
  }

  .car_foot_settle {
    float: right;

  }

  .piece {
    float: left;
    height: 45px;
    line-height: 45px;
  }

  .totalMoney {
    float: left;
    margin-left: 20px;
    height: 45px;
    line-height: 45px;
  }

  .settle_accounts {
    float: left;
    margin-left: 20px;
    height: 45px;
    line-height: 45px;
  }

  .piece_num {
    color: red;
  }

  .total_text {
    color: red;
    font-size: 18px;
  }

  .settle_button {
    width: 100px;
    height: 45px;
    line-height: 45px;
    border: none;
    outline: none;
    background-color: red;

  }

  .settle_button:disabled {
    background-color: #eeefff;
  }

  .shop_info {
    width: 100%;
    height: 20px;
    margin-top: 20px;
    margin-bottom: 10px;
    font-size: 12px;
    align-items: center;
    display: flex;
  }

  .shop_info_check_all {
    position: relative;
    width: 10px;
    left: -20px;
  }

  .shop_info li a {
    text-decoration: none;
    margin-right: 10px;
    color: #3c3c3c;
  }

  .shop_info li a:hover {
    color: red;
    text-decoration: underline;
  }

  .shop_icon {
    width: 16px;
    height: 16px;
  }

  .shop_discount {
    width: 60px;
    height: 20px;
    margin-left: 10px;
  }

  .product {
    width: 100%;
    border: 1px solid #DCDCDC;
    background: #F5F5F5;
  }

  .selected_styles {
    background: lightgoldenrodyellow;
  }

  .product_details {
    width: 100%;
    height: 145px;
    padding-left: 20px;
  }

  .product_description {
    width: 100%;
    height: 25px;
    background: white;
    font-size: 12px;
    padding-left: 50px;
    align-items: center;
    display: flex;
  }

  .product_description_bg {
    width: fit-content;
    background: #eee;
    height: 20px;
    line-height: 20px;
  }

  .product_check {
    float: left;
    margin-top: -8px;
    padding-top: 20px;
  }

  .product_img {
    float: left;
    padding-top: 20px;
  }

  .product_shop_info {
    height: 100px;
    float: left;
    padding-left: 10px;
    position: relative;
    width: 220px;
    padding-right: 20px;
    padding-top: 20px;
  }

  .product_shop_name {
    font-size: 12px;
    text-align: left;
  }

  .product_shop_name a {
    text-decoration: none;
    letter-spacing: 2px;
    color: #3c3c3c;
    align-content: left;
  }

  .product_shop_name a:hover {
    color: red;
    text-decoration: underline;
  }

  .product_shop_icon {
    position: absolute;
    bottom: 0px;
    width: fit-content;
  }

  .product_type_select {
    width: 155px;
    height: 120px;
    font-size: 12px;
    text-align: left;
    float: left;
    position: relative;
    padding-bottom: 10px;
    color: #3c3c3c;
    border: 1px dashed transparent;
  }

  .product_type_select:hover {
    border: 1px dashed #F00
  }

  .product_type_all:first-child {
    padding-top: 20px;
  }

  .product_type {
    width: 125px;
    margin-bottom: 10px;
    margin-left: 15px;
  }

  .product_edit {
    width: fit-content;
    position: absolute;
    top: 0;
    right: 0;
  }

  .product_edit_button {
    color: white;
    background: red;
    border: none;
    outline: none;
  }

  .product_edit_type_true {
    display: block;
  }

  .product_edit_type_false {
    display: none;
  }

  .product_price {
    width: 105px;
    float: left;
    padding-top: 20px;
    text-align: left;
    padding-left: 20px;
  }

  .product_price_origin {
    width: fit-content;
    font-size: 14px;
    color: grey;
    text-decoration: line-through;
  }

  .product_price_current {
    width: fit-content;
    font-size: 14px;
    font-weight: bold;
  }

  .product_number {
    width: 90px;
    float: left;
    padding-top: 20px;
  }

  .product_number_content {
    width: fit-content;
    height: 24px;
    background: #eee;
  }

  .product_number_button {
    width: 24px;
    float: left;
    margin: 0px auto;
    border: 1px solid transparent;
  }

  .product_number_button button {
    width: 24px;
    height: 24px;
    outline: none;
    background: transparent;
    border: 1px solid transparent;
  }

  .product_number_button button:hover {
    background: transparent;
    border: 1px solid orange;
  }

  .product_number_input {
    width: fit-content;
    text-align: center;
    float: left;
    margin: 0px auto;
  }

  .product_number_input input {
    width: 30px;
    height: 24px;
    text-align: center;
    box-sizing: border-box;
  }

  .product_number_input input::-webkit-inner-spin-button {
    -webkit-appearance: none;
  }

  .product_number_input input::-webkit-outer-spin-button {
    -webkit-appearance: none;
  }

  .product_amount {
    width: 100px;
    float: left;
    padding-top: 20px;
  }

  .product_total_price {
    width: 100px;
    font-size: 16px;
    color: red;
    font-weight: bold;
    word-wrap: break-word;
  }

  .product_operation {
    width: 100px;
    float: left;
    padding-top: 20px;
    text-align: left;
    margin-left: 20px;
    line-height: 15px;
    color: #3c3c3c;
  }

  .product_operation button {
    width: fit-content;
    border: none;
    background: transparent;
    outline: none;
    font-size: 12px;
  }

  .product_operation button:hover {
    color: red;
    text-decoration: underline;
  }
</style>