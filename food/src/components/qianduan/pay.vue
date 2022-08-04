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
                  type="submit" @click="shuosuo"
                  style="text-align: center"
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
    <div class="concent">
      <!--地址 -->
      <div class="address">
         <el-button type="primary" size="mini" @click="addressadd" style="margin-top: 22px;">添加地址</el-button><br>
        <h3>收货地址</h3>
        <div class="control"></div>
        <div class="clear"></div>
        <ul>
          <div class="per-border"></div>
          <li
            :class="
              items.Addressstaus == 'true'
                ? 'user-addresslist defaultAddr'
                : 'user-addresslist'
            "
            @click="addressclick(items)"
            v-for="items in addressdt"
            :key="items.Addressid"
          >
            <div class="address-left">
              <div class="user DefaultAddr">
                <span class="buy-address-detail">
                  <span class="buy-user">{{ items.Addressname }}</span>
                  <span class="buy-phone">{{ items.Addressphone }}</span>
                </span>
              </div>
              <div class="default-address DefaultAddr">
                <span class="buy-line-title buy-line-title-type"
                  >收货地址：</span
                >
                <span class="buy--address-detail">{{
                  items.Addresssuozaidiqu
                }}</span>
                <span class="buy--address-detail">{{
                  items.Addressxiangxidiqu
                }}</span>
              </div>
              <ins class="deftip" v-if="items.Addressstaus == 'true'"
                >默认地址</ins
              >
              <ins class="deftip" v-else></ins>
            </div>
          </li>
          <div class="per-border"></div>
        </ul>
        <div class="clear"></div>
        <hr />
        <p>
          确认收货地址：<span>{{ dt }}</span>
        </p>

        <div class="clear"></div>
      </div>
      <!--物流 -->
      <div class="logistics">
        <h3>选择物流方式</h3>
        <el-radio-group v-model="radio1">
          <el-radio label="圆通" border>圆通</el-radio>
          <el-radio label="申通" border>申通</el-radio>
          <el-radio label="韵达" border>韵达</el-radio>
          <el-radio label="中通" border>中通</el-radio>
          <el-radio label="顺丰" border>顺丰</el-radio>
        </el-radio-group>
      </div>
      <div class="clear"></div>

      <!--支付方式-->
      <div class="logistics">
        <h3>选择支付方式</h3>
        <!--   <img src="../../assets/images/weizhifu.jpg" style="width:100px" /> -->
        <el-radio-group v-model="radio2">
          <el-radio-button label="微信"></el-radio-button>
        </el-radio-group>
      </div>
      <div class="clear"></div>

      <!--订单 -->
      <div class="concent">
        <div id="payTable">
          <h3>确认订单信息</h3>
          <div class="clear"></div>

          <section class="car_main">
            <!--顶部列表-->
            <div class="car_head">
              <ul class="car_top">
                <li class="car_check_all">
                  <!-- <input type="checkbox" id="check_all" v-model="checked_all" @click="all_products_checked"/>
            <label for="check_all">全选</label> -->
                </li>
                <li class="car_information">商品信息</li>
                <li class="car_price">单价</li>
                <li class="car_number">数量</li>
                <li class="car_amount">金额</li>
              </ul>
            </div>
            <!--购物车为空时展示页面-->
            <template v-if="goods.length == 0">
              <div class="cart_empty">
                您的购物车还是空的哦，快去挑选您喜欢的东西吧.
              </div>
            </template>
            <!--购物车详情展示-->
            <template v-else>
              <div v-for="(shop, shop_index) in goods" :key="shop.Goodkoweiid">
                <!--当店铺下面有已购买商品的时候显示该店铺和商品信息-->
                <div v-if="shop.list.length != 0">
                  <div
                    v-for="(product, product_index) in shop.list"
                    class="product"
                    v-bind:class="[product.shoppcheck ? 'selected_styles' : '']"
                    :key="product.Goodkoweiid"
                  >
                    <div class="product_details">
                      <!--商品是否选中-->
                      <div class="product_check">
                        <input
                          type="checkbox"
                          v-model="product.shoppcheck"
                          @click="
                            product_checked_click(shop_index, product_index)
                          "
                        />
                      </div>

                      <!--商品图片-->
                      <div class="product_img">
                        <img
                          :src="
                            'http://81.68.132.153:7070/img/' +
                            product.Good.GoodImage
                          "
                          style="width: 100px; height: 100px"
                        />
                      </div>

                      <!--商品名称-->
                      <div class="product_shop_info">
                        <div class="product_shop_name">
                          <a :href="product.href">{{
                            product.Good.GoodName
                          }}</a>
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
                            <span>{{ product.Goodkoweiname }}</span>
                          </div>
                        </div>
                      </div>
                      <!-- //商品价格 -->
                      <div class="product_price">
                        <div
                          v-if="product.Good.GoodPrice"
                          class="product_price_origin"
                        >
                          ￥{{ product.Good.GoodPrice | priceFilter }}
                        </div>
                        <div class="product_price_current">
                          ￥{{ product.Good.GoodPrcieper | priceFilter }}
                        </div>
                      </div>
                      <!--商品数量-->
                      <div class="product_number">
                        <div class="product_number_content">
                          <div class="product_number_button">
                            <button
                              v-if="product.Good.Goodnum > 1"
                              @click="product_reduce(shop_index, product_index)"
                            >
                              -
                            </button>
                          </div>
                          <div class="product_number_input">
                            <input
                              type="number"
                              v-model="product.Good.Goodnum"
                              readonly
                            />
                          </div>
                          <div
                            class="product_number_button"
                            @click="product_add(shop_index, product_index)"
                          >
                            <button>+</button>
                          </div>
                        </div>
                      </div>

                      <!--金额统计-->
                      <div class="product_amount">
                        <div class="product_total_price">
                          ￥{{
                            product_total_price(shop_index, product_index)
                              | priceFilter
                          }}
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
                <div class="piece">
                  已选商品
                  <strong class="piece_num">{{ selected_products }}</strong> 件
                </div>
                <div class="totalMoney">
                  合计 (不含运费) :
                  <strong class="total_text">{{
                    total_amount | priceFilter
                  }}</strong>
                  元
                </div>
                <div class="settle_accounts"></div>
              </div>
            </div>
            <div class="order-go clearfix">
              <div class="pay-confirm clearfix">
                <div class="box">
                  <div tabindex="0" id="holyshit267" class="realPay">
                    <em class="t">实付款：</em>
                    <span class="price g_price">
                      <span>¥</span>
                      <em class="style-large-bold-red" id="J_ActualFee">{{
                        total_amount | priceFilter
                      }}</em>
                    </span>
                  </div>

                  <div id="holyshit268" class="pay-address">
                    <p class="buy-footer-address">
                      <span class="buy-line-title buy-line-title-type"
                        >寄送至：</span
                      >
                      <span class="city">{{ orderaddressname }}</span>
                    </p>
                    <p class="buy-footer-address">
                      <span class="buy-line-title">收货人：</span>
                      <span class="buy-address-detail">
                        <span class="buy-user">{{ orderaddressphone }}</span>
                      </span>
                    </p>
                  </div>
                </div>

                <div id="holyshit269" class="submitOrder">
                  <div class="go-btn-wrap">
                    <button
                      class="settle_button"
                      style="color: white"
                      :disabled="selected_products == 0 ? true : false"
                      @click="shop_settle"
                    >
                      提交订单
                    </button>
                  </div>
                </div>
                <div class="clear"></div>
              </div>
            </div>
          </section>
        </div>
        <div class="clear"></div>
        <div class="pay-total">
          <div class="clear"></div>
        </div>
        <!--含运费小计 -->
      </div>
      <div class="clear"></div>
    </div>
    <el-dialog
      title="支付"
      :visible.sync="dialogVisible"
      width="30%"
      @close="fangs"
    >
      <div slot="footer">
        <div
          id="qrcode"
          v-loading="loading"
          element-loading-text="拼命加载中"
          element-loading-spinner="el-icon-loading"
          element-loading-background="rgba(0, 0, 0, 0.8)"
          style="width: 110px; position: relative; bottom: 30px"
        ></div>
        <div style="width: 330px; position: relative; bottom: 17px; right: 9px">
          注：若二维码过期失效，请刷新页面重新进入支付！
        </div>
      </div>
      <p>
        使用<span style="color: green; font-weight: bold">微信</span
        >扫一扫二维码进行支付
      </p>
      <span slot="footer" class="dialog-footer">
        <el-button @click="fang">返回</el-button>
      </span>
    </el-dialog>
     <!-- 添加收货地址 -->
    <el-dialog
      title="添加地址"
      :visible.sync="addVisible"
      width="50%" @close="addDialogClosed"
    >
      <!-- :rules="updateformRules" ref="updateformRel" -->
      <el-form
        :model="addform"
        label-width="70px"
        class="demo-ruleForm"
        :rules="addformRules"
        ref="updateformref"
      >
        <el-form-item
          label="收货人"
          style="position: relative; top: 0px; left: 0px"
          prop="Addressname"
        >
          <el-input v-model="addform.Addressname" placeholder="请输入收货人"></el-input>
        </el-form-item>
         <el-form-item
          label="所在地区"
          style="position: relative; top: 0px; left: 0px"
          prop="Addresssuozaidiqu"
        >
          <el-input v-model="addform.Addresssuozaidiqu" placeholder="请选择省/市/区/街道"></el-input>
        </el-form-item>
        <el-form-item
          label="详细地址"
          style="position: relative; top: 0px; left: 0px"
          prop="Addressxiangxidiqu"
        >
          <el-input v-model="addform.Addressxiangxidiqu" placeholder="请输入详细地址详细，如道路、门牌号、小区、楼栋号】单元等信息"></el-input>
        </el-form-item>
        <el-form-item
          label="邮编"
          style="position: relative; top: 0px; left: 0px"
          prop="Addressyoubian"
        >
          <el-input v-model="addform.Addressyoubian" placeholder="请输入邮编"></el-input>
        </el-form-item>
         <el-form-item
          label="手机号"
          style="position: relative; top: 0px; left: 0px"
          prop="Addressphone"
        >
          <el-input v-model="addform.Addressphone" placeholder="请输入电话号码"></el-input>
        </el-form-item>
      </el-form>
      <span slot="footer" class="dialog-footer">
        <el-button @click="addVisible = false">取 消</el-button>
        <el-button type="primary" @click="addtianj">确 定</el-button>
      </span>
    </el-dialog>
  </div>
</template>
<script>
/*! jQuery v1.7.1 jquery.com | jquery.org/license */
import $ from "jquery";
import QRCode from "qrcodejs2";
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
      timer: "",
      loading: true,
      //控制微信支付的显示和隐藏
      dialogVisible: false,
      //接收订单信息:
      goods: [
        {
          list: [],
        },
      ],
      // 其他属性数据
      checked_all: false,
      num: "",
      radio1: "圆通",
      radio2: "微信",
      //接收用户的id
      usid: "",
      //接收所有地址的数据
      addressdt: [],
      //接收口味名称
      goodkows: "",
      //接收数量
      nums: "",
      //接收用户选的地址
      dt: "",
      //默认打钩的样式
      addressstyle: "",
      url: "付款成功",
      //订单的数据
      orderfrom: {
        Ordernum: "",
        Ordersum: "",
        Goodid: "",
        Orderwuliu: "",
        Goodtypetwoid: "",
        Addressid: "",
        Ordertime: "",
      },
      //接收订单的总金额
      ordersums: "",
      ordertrue: "",
      //接收从购物车点击购买传的口味id，用户id,数量
      shoppid: "",
      //接收口味的id
      shoppidkow: {
        shoppidkowid: "",
      },
      //接收商品的数量
      shoppidgoodnums: "",
      //接收商品选中的数据
      shoppkowidlist: [],
      //接收收货人、手机号
      orderaddressphone: "",
      orderaddressname: "",
      numss:"",
      ordersids:"",
      namess:"",
       //控制修改是否显示和隐藏
      addVisible:false,
      addform:{},
      addformRules: {
		Addressname: [
          { required: true, message: "请输入收货人", trigger: "blur" }
        ],
        Addresssuozaidiqu: [
          { required: true, message: "请输入地区", trigger: "blur" }
        ],
		Addressxiangxidiqu: [
          { required: true, message: "请输入详细地址", trigger: "blur" }
        ],
        Addressyoubian: [
          { required: true, message: "请输入邮编", trigger: "blur" }
        ],
        Addressphone: [
          { required: true, message: "请输入用户手机号", trigger: "blur" },
          { validator: checkMobile, trigger: "blur" },
        ]
      },
    };
  },
  methods: {
    // 结算
    shop_settle() {
      
      if (this.addressdt.length==0) {
        this.$message.error("收货地址为空，请添加收货地址");  
      }
      else{
        this.dialogVisible = true;
      this.qrcode();}
    },
    // 商品总价
    product_total_price(shop_index, product_index) {
      var product = this.goods[shop_index].list[product_index];
      return product.Good.Goodnum * product.Good.GoodPrcieper;
    },
    // 减购商品，每次减少1
    product_reduce(shop_index, product_index) {
      var product = this.goods[shop_index].list[product_index];
      if (product.Good.Goodnum - 1) {
        product.Good.Goodnum--;
      }
    },
    // 加购，每次加1
    product_add(shop_index, product_index) {
      var product = this.goods[shop_index].list[product_index];
      if (product.Good.Goodnum + 1 < 100) {
        product.Good.Goodnum++;
      }
    },
    // 删除购买商品
    product_del(sender) {
      this.$axios.get("/api/Food/shoppingDelete?id=" + sender).then((s) => {
        if (s.data == "删除成功") {
          this.$message.success("删除成功");
          this.getGoods();
        } else {
          this.$message.error("删除失败!");
        }
      });
      // this.goods[shop_index].list.splice(product_index, 1)
    },
    // 店铺下属商品全部选择时
    shop_all_check(shop_index) {
      var shop = this.goods[shop_index];
      shop.all_checked = !shop.all_checked;
      for (var i = 0; i < shop.list.length; i++) {
        shop.list[i].shoppcheck = shop.all_checked;
      }
    },
    // 商品选择时
    product_checked_click(shop_index, product_index) {
      var product = this.goods[shop_index].list[product_index];
      product.shoppcheck = !product.shoppcheck;
      this.shoppkowidlist.push(product.Goodkoweiid);
      console.log("shoppkowidlist");
      console.log(this.shoppkowidlist);
      // 检测是否该店铺内的商品全选
      for (var i = 0; i < this.goods[shop_index].list.length; i++) {
        if (!this.goods[shop_index].list[i].shoppcheck) {
          this.goods[shop_index].all_checked = false;
          this.checked_all = false;
          return;
        }
      }
      this.goods[shop_index].all_checked = true;

      // 检测购物车内的商品是否全部选中
      for (let i = 0; i < this.goods.length; i++) {
        if (!this.goods[i].all_checked) {
          this.checked_all = false;
          return;
        }
      }
      this.checked_all = true;
    },
    // 检测购物车内的商品全部
    all_products_checked() {
      this.checked_all = !this.checked_all;
      for (var i = 0; i < this.goods.length; i++) {
        this.goods[i].all_checked = this.checked_all;
        for (var j = 0; j < this.goods[i].list.length; j++) {
          this.goods[i].list[j].shoppcheck = this.checked_all;
        }
      }
    },
    //查询所有购物车
    getgoodlist() {
      this.$axios.get("/api/Food/shoppings").then((s) => {
        // this.goods[0].list=s.data;
        // console.log(s.data);
        // console.log(this.goods[0].list);
      });
    },
    //根据用户id查询商品所有
    getGoods() {
      //一种购物车的口味id查询商品
      if (this.shoppidkow.shoppidkowid != "") {
        this.$axios
          .post(
            "/api/Food/goodkoweisidzhu",
            this.$qstring.stringify({
              goodkoweiid: this.shoppidkow.shoppidkowid,
            })
          )
          .then((l) => {
            if (l.data != "") {
              this.goods[0].list = l.data;
              for (
                let index = 0;
                index < this.shoppidgoodnums.length;
                index++
              ) {
                this.goods[0].list[index].Good.Goodnum =
                  this.shoppidgoodnums[index];
                console.log(this.goods[0].list[index].Good.Goodnum);
              }
              console.log("商品所有");
              console.log(l.data);
            }
          });
      } else {
        //二根据口味名称查询商品
        this.$axios
          .get("/api/Food/goodkoweiz?name=" + this.goodkows)
          .then((d) => {
            if (d.data != "") {
              if (this.nums!="") {
                this.goods[0].list = d.data;
              this.goods[0].list[0].Good.Goodnum = this.nums;
              console.log("商品所有");
              console.log(this.goods[0].list);
              }
              
              if (this.numss!="") {
                //  this.goods[0].list = d.data;
              
               console.log("商品所有s");
              console.log(this.goods[0].list[0]);
                let dt=d.data;
          let arr1 = []; //存id
          //循环如果有相同的，就存一个，去重复
	for(let i in dt){
		if(arr1.indexOf(dt[i].Good.GoodfuName) == -1){
			arr1.push(dt[i].Good.GoodfuName);
		this.goods[0].list.push(dt[i]);
		}
	}
  this.goods[0].list[0].Good.Goodnum = this.numss;
              }
            }
          });
      }
    },
    xiang(sender) {
      // if (sender.Goodkowei.Goodkoweiname1==this.kowd) {
      // }
    },
    //跳转首页
    s() {
      this.$router.push("/");
    },
    //查询所有地址
    getaddress() {
      if (this.shoppid != "") {
        this.$axios.get("/api/Food/addresses?id=" + this.shoppid).then((s) => {
          this.addressdt = s.data;
          console.log("地址");
          console.log(this.addressdt);
        });
      } else {
        this.$axios.get("/api/Food/addresses?id=" + this.usid).then((s) => {
          this.addressdt = s.data;
          console.log("地址");
          console.log(this.addressdt);
        });
      }
    },
    //点击地址赋值给dt
    addressclick(items) {
      this.dt =
        items.Addresssuozaidiqu +
        items.Addressxiangxidiqu +
        items.Addressname +
        " " +
        items.Addressphone;
    },
    //查询Addressstaus=true的地址
    gettrueaddress() {
      if (this.shoppid != "") {
        this.$axios
          .get("/api/Food/addressestrue?id=" + this.shoppid)
          .then((s) => {
            this.dt =
              s.data[0].Addresssuozaidiqu +
              s.data[0].Addressxiangxidiqu +
              s.data[0].Addressname +
              " " +
              s.data[0].Addressphone;
            this.ordertrue = s.data[0].Addressphone;
            this.orderaddressphone =
              s.data[0].Addressname + " " + s.data[0].Addressphone;
            this.orderaddressname =
              s.data[0].Addresssuozaidiqu + s.data[0].Addressxiangxidiqu;
          });
      } else {
        this.$axios.get("/api/Food/addressestrue?id=" + this.usid).then((s) => {
          this.dt =
            s.data[0].Addresssuozaidiqu +
            s.data[0].Addressxiangxidiqu +
            s.data[0].Addressname +
            " " +
            s.data[0].Addressphone;
          this.ordertrue = s.data[0].Addressphone;
          this.orderaddressphone =
            s.data[0].Addressname + " " + s.data[0].Addressphone;
          this.orderaddressname =
            s.data[0].Addresssuozaidiqu + s.data[0].Addressxiangxidiqu;
        });
      }
    },
    qrcode() {
      // 和div的id相同 必须是id  class类名会报错
      // 第二参数是他的配置项
      // let qrco=this.$$refs.qrCodes;
      this.$nextTick(function () {
        let qrBox = document.getElementById("qrcode");
        let qrCode = new QRCode(qrBox, {
          width: 150,
          height: 150,
          render: "canvas",
          text: this.url,
          colorDark: "#000",
          colorLight: "#fff",
          // src:'../../assets/images/gift_stamp_2.png'
        });
      });
      this.loading = false;
      if (this.dialogVisible == true) {
        this.timer = setInterval(() => {
          // 通过定时器每间隔一会去请求查询微信支付状态（具体参数根据项目需要而定）
          this.loading = true;
          this.handleQueryWxPayStatus();
        }, 3000);
      } else {
        alert(12);
      }
    },
    fangs(){
this.dialogVisible = false;
 document.getElementById("qrcode").innerHTML = "";
    },
    //当dialogVisible=false 二维码就为空
    fang() { 
      clearInterval(this.timer);
      this.dialogVisible = false;
   if (this.shoppidkow.shoppidkowid.length != 0) {

        for (let i = 0; i < this.shoppkowidlist.length; i++) {     
          this.orderfrom.Ordernum = this.goods[0].list[i].Good.Goodnum;
          console.log(this.orderfrom.Ordernum);
          this.orderfrom.Goodid = this.goods[0].list[i].Good.Goodid;
          console.log(this.orderfrom.Goodid);
          this.orderfrom.Orderwuliu = this.radio1;
          console.log(this.orderfrom.Orderwuliu);
          this.orderfrom.Goodtypetwoid = this.goods[0].list[i].Goodkoweiid;
          console.log(this.orderfrom.Goodtypetwoid);
        }
        this.orderfrom.Ordersum = this.ordersums;
        console.log(this.orderfrom.Ordersum);
        this.$axios
          .get("/api/Food/addressesname?name=" + this.ordertrue)
          .then((n) => {
            this.orderfrom.Addressid = n.data[0].Addressid;

            for (let j = 0; j < this.shoppkowidlist.length; j++) {
              this.nowtiem(); //获取当前时间并赋值给Ordertime
              console.log(this.orderfrom.Ordertime);
              console.log("Ordertime");
              this.$axios
                .get("/api/Food/addressesname?name=" + this.ordertrue)
                .then((n) => {
                  this.orderfrom.Addressid = n.data[j].Addressid;
                  this.$axios
                    .post("/api/Food/ordershoppingadd", this.orderfrom)
                    .then((d) => {
                      if (d.data == "添加成功") {
                        clearInterval(this.timer);
                        this.$message.success("添加订单成功!");
                      } else {
                        this.$message.error("添加订单失败失败!");
                      }
                    });
                });
            }
          });
      } else {
        this.orderfrom.Ordernum = this.goods[0].list[0].Good.Goodnum;
        this.orderfrom.Ordersum = this.ordersums;
        this.orderfrom.Goodid = this.goods[0].list[0].Good.Goodid;
        this.orderfrom.Orderwuliu = this.radio1;
        this.orderfrom.Goodtypetwoid = this.goods[0].list[0].Goodkoweiid;
        this.nowtiem(); //获取当前时间并赋值给Ordertime
        this.$axios
          .get("/api/Food/addressesname?name=" + this.ordertrue)
          .then((n) => {
            this.orderfrom.Addressid = n.data[0].Addressid;
            this.$axios
              .post("/api/Food/ordershoppingadd", this.orderfrom)
              .then((d) => {
                if (d.data == "添加成功") {
                 
                  this.$message.success("添加订单成功!");
                } else {
                  this.$message.error("添加订单失败失败!");
                }
              });
          });
      }
      document.getElementById("qrcode").innerHTML = "";
    },
    //获取当前时间
    nowtiem() {
      let now = new Date();
      let _month =
        10 > now.getMonth() + 1
          ? "0" + (now.getMonth() + 1)
          : now.getMonth() + 1;
      let _day = 10 > now.getDate() ? "0" + now.getDate() : now.getDate();
      let _hour = 10 > now.getHours() ? "0" + now.getHours() : now.getHours();
      let _minute =
        10 > now.getMinutes() ? "0" + now.getMinutes() : now.getMinutes();
      let _second =
        10 > now.getSeconds() ? "0" + now.getSeconds() : now.getSeconds();
      this.orderfrom.Ordertime =
        now.getFullYear() +
        "-" +
        _month +
        "-" +
        _day +
        " " +
        _hour +
        ":" +
        _minute +
        ":" +
        _second;
    },
    //支付
    handleQueryWxPayStatus() {
      
      if (this.shoppidkow.shoppidkowid.length != 0) {
        this.loading = true;
        for (let i = 0; i < this.shoppkowidlist.length; i++) {
          this.orderfrom.Ordernum = this.goods[0].list[i].Good.Goodnum;
          console.log(this.orderfrom.Ordernum);
          this.orderfrom.Goodid = this.goods[0].list[i].Good.Goodid;
          console.log(this.orderfrom.Goodid);
          this.orderfrom.Orderwuliu = this.radio1;
          console.log(this.orderfrom.Orderwuliu);
          this.orderfrom.Goodtypetwoid = this.goods[0].list[i].Goodkoweiid;
          console.log(this.orderfrom.Goodtypetwoid);
          console.log("this.shoppkowidlist.length");
      console.log(this.shoppkowidlist);
        }
        this.orderfrom.Ordersum = this.ordersums;
        console.log(this.orderfrom.Ordersum);
 for (let j = 0; j < this.shoppkowidlist.length; j++) {
  // alert(this.shoppkowidlist.length)
        this.$axios
          .get("/api/Food/addressesname?name=" + this.ordertrue)
          .then((n) => {
           
            this.orderfrom.Addressid = n.data[0].Addressid;
            console.log("this.shoppkowidlist.length");
                console.log(this.shoppkowidlist);
           
              this.nowtiem(); //获取当前时间并赋值给Ordertime
              console.log(this.orderfrom.Ordertime);
              console.log("Ordertime");
              
              this.$axios
                .get("/api/Food/addressesname?name=" + this.ordertrue)
                .then((n) => {
                  
                  this.orderfrom.Addressid = n.data[j].Addressid;
                  
                  this.$axios
                    .post("/api/Food/ordershoppingadd", this.orderfrom)
                    .then((d) => {
                      if (d.data=="数量为负") {
                     
                        clearInterval(this.timer);
                           this.$message.error("商品的库存为负,非常抱歉，请联系商家");  
                      }
                      else{
                      if (d.data == "添加成功") {
                        clearInterval(this.timer);
                        this.$message.success("添加订单成功!");
                       
                        this.$axios
                          .get(
                            "/api/Food/ordertime?times=" +
                              this.orderfrom.Ordertime
                          )
                          .then((s) => {
                            if (s.data == "付款成功") {
                              // 清除定时器
                             
                              // 三秒后跳转到课程详情页面
                              setTimeout(() => {
                              if (this.shoppkowidlist.length) {
                                this.loading = false;
                                this.$message.success("付款成功");  
                                console.log("清除定时器");
                              clearInterval(this.timer);
                                this.$router.push({
                            path: "/qianduan/ordersuccess",
                            query: {
                              addressids: this.orderfrom.Addressid,
                              userid: this.shoppid,
                              sum:this.orderfrom.Ordersum
                            },
                          });
                              }
                              
                              }, 4000);
                            }
                          });
                      } 
                      else {
                        clearInterval(this.timer);
                           this.$message.error("商品的库存为负,非常抱歉，请联系商家");  
                      }
                      }
                    });
                });
          });
          }
      } else {
        this.loading = true;
        this.orderfrom.Ordernum = this.goods[0].list[0].Good.Goodnum;
        this.orderfrom.Ordersum = this.ordersums;
        this.orderfrom.Goodid = this.goods[0].list[0].Good.Goodid;
        this.orderfrom.Orderwuliu = this.radio1;
        this.orderfrom.Goodtypetwoid = this.goods[0].list[0].Goodkoweiid;
        this.nowtiem(); //获取当前时间并赋值给Ordertime
        this.$axios
          .get("/api/Food/addressesname?name=" + this.ordertrue)
          .then((n) => {
            this.orderfrom.Addressid = n.data[0].Addressid;  
           
            this.$axios
              .post("/api/Food/ordershoppingadd", this.orderfrom)
              .then((d) => {
                if (d.data == "添加成功") {
                  clearInterval(this.timer);
                  this.$message.success("添加订单成功!");
                  this.$axios
                    .get(
                      "/api/Food/ordertime?times=" + this.orderfrom.Ordertime
                    )
                    .then((s) => {
                      if (s.data == "付款成功") {
                        // 清除定时器
                        console.log("清除定时器");
                        clearInterval(this.timer);
                        this.$axios.get('/api/Food/orderdelete?id='+this.ordersids).then(l=>{
                            if (l.data=="删除成功") {
                              console.log();
                            }
                        });
                        // 三秒后跳转到课程详情页面
                        setTimeout(() => {
                          this.loading = false;
                          this.$message.success("付款成功");
                          this.$router.push({
                            path: "/qianduan/ordersuccess",
                            query: {
                              addressids: this.orderfrom.Addressid,
                              userid: this.shoppid,
                              sum:this.orderfrom.Ordersum
                            },
                          });
                        }, 4000);
                      }
                    });
                } else {
                  this.$message.error("商品的库存为负,非常抱歉，请联系商家");  
                }
              });
          });
      }
    },
    //跳转用户安全
    usersafety() {
      this.$router.push({
        path: "/qianduan/usersafety",
        query: {
          userids: this.shoppid,
        },
      });
    },
    //跳转到用户信息
    security() {
      this.$router.push({
        path: "/qianduan/security",
        query: {
          userids: this.shoppid,
        },
      });
    },
    //跳转到收货地址
    userdizhi() {
      this.$router.push({
        path: "/qianduan/userdizhi",
        query: {
          userids: this.shoppid,
        },
      });
    },
    //跳转到收藏夹
    usershouchang() {
      this.$router.push({
        path: "/qianduan/shouchang",
        query: {
          userids: this.shoppid,
        },
      });
    },
    //跳转到购物车
    goodshopp() {
      this.$router.push({
        path: "/qianduan/shopgowuche",
        query: {
          userids: this.shoppid,
        },
      });
    },
    //跳转到收藏夹
    goodfoot() {
      this.$router.push({
        path: "/qianduan/shouchang",
        query: {
          userids: this.shoppid,
        },
      });
    },
    //退出
    tui() {
      window.sessionStorage.clear();
      this.$router.push("/Login");
    },
    getnames(){
     this.$axios.get('/api/Food/foodUsersid?pagenum='+this.shoppid).then(s=>{
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
    //添加
    addressadd(){
      this.addVisible=true;
    },
    //添加数据
addtianj(){
  this.addform.Userxixids=this.shoppid;
  this.addform.Addressstaus="true";
  this.$refs.updateformref.validate((valid) =>{
   if (valid) {
     this.$axios.post('/api/Food/addressADD',this.addform).then(d=>{
  if (d.data=="添加成功") {
   this.addVisible=false;
   this.getaddress();
    this.$message.success('添加成功!');
    window.location.reload();
    console.log(d.data);
  }
  else{
    this.$message.error('添加失败!')
  }
})
   }
   else{
     console.log('error submit!!');
            return false;
   }
  })
},
  },
  mounted() {},
  filters: {
    // 金额显示过滤 两位小数点，不足补0
    priceFilter(value) {
      var values = Math.round(parseFloat(value) * 100) / 100;
      var xsd = value.toString().split(".");
      if (xsd.length == 1) {
        values = value.toString() + ".00";
        return values;
      }
      if (xsd.length > 1) {
        if (xsd[1].length < 2) {
          values = value.toString() + "0";
        }
        return values;
      }
    },
  },

  computed: {
    // 已选择商品数目
    selected_products() {
      var selected_products = 0;
      for (var i = 0; i < this.goods.length; i++) {
        var product = this.goods[i].list;
        for (var j = 0; j < product.length; j++) {
          if (product[j].shoppcheck) {
            // selected_products=product[i].shoppingnum++;
            selected_products =
              parseInt(product[j].Good.Goodnum) + selected_products;
          }
        }
        // selected_products=selected_products++;
      }
      return selected_products;
    },

    // 购买商品总金额
    total_amount() {
      var _this = this;
      var total_price = 0.0;
      for (var i = 0; i < this.goods.length; i++) {
        var product = this.goods[i].list;
        for (var j = 0; j < product.length; j++)
          if (product[j].shoppcheck) {
            total_price +=
              parseInt(product[j].Good.Goodnum) * product[j].Good.GoodPrcieper;
          }
      }
      _this.ordersums = total_price;

      return total_price;
    },

    // 购物车全选
    all_checked() {
      for (var i = 0; i < this.goods.length; i++) {
        if (!this.goods[i].all_checked) {
          return false;
        }
      }
      return true;
    },
  },
  created() {
    if (location.href.indexOf("#reloaded") == -1) {
      location.href = location.href + "#reloaded";
      location.reload();
    }
    var usid = this.$route.query.id;
    if (usid != null) {
      this.usid = usid;
    }
    var goodkows = this.$route.query.koweis;
    if (goodkows != null) {
      this.goodkows = goodkows;
    }
    var nums = this.$route.query.nums;
    if (nums != null) {
      this.nums = nums;
    }
     var numss = this.$route.query.numss;
    if (numss != null) {
      this.numss = numss;
    }
    var shoppid = this.$route.query.shoppid;
    if (shoppid != null) {
      this.shoppid = shoppid;
    }
    var shoppidkowid = this.$route.query.shoppidkowid;
    if (shoppidkowid != null) {
      this.shoppidkow.shoppidkowid = shoppidkowid;
    }
    var shoppidgoodnums = this.$route.query.shoppidgoodnums;
    if (shoppidgoodnums != null) {
      this.shoppidgoodnums = shoppidgoodnums;
    }
     var ordersids = this.$route.query.ordersids;
    if (ordersids != null) {
      this.ordersids = ordersids;
    }
    this.getGoods();
    this.getaddress();
    this.gettrueaddress();
    this.getnames();
    if (this.dialogVisible == false) {
      document.getElementById("qrcode").innerHTML = "";
    }
  },
};
$(function () {
  $(".add").click(function () {
    var t = $(this).parent().find("input[class*=text_box]");
    t.val(parseInt(t.val()) + 1);
  });
  $(".min").click(function () {
    var t = $(this).parent().find("input[class*=text_box]");
    t.val(parseInt(t.val()) - 1);
    if (parseInt(t.val()) < 0) {
      t.val(0);
    }
  });
});

// <
// !--兼容IE浏览器-- >
if (!document.getElementsByClassName) {
  document.getElementsByClassName = function (cls) {
    var ret = [];
    var els = document.getElementsByTagName("*");
    for (var i = 0, len = els.length; i < len; i++) {
      if (
        els[i].className.indexOf(cls + " ") >= 0 ||
        els[i].className.indexOf(" " + cls + " ") >= 0 ||
        els[i].className.indexOf(" " + cls) >= 0
      ) {
        ret.push(els[i]);
      }
    }
    return ret;
  };
}

//地址选择
$(function () {
  $(".user-addresslist").click(function () {
    $(this).addClass("defaultAddr").siblings().removeClass("defaultAddr");
  });
  $(".logistics").each(function () {
    var i = $(this);
    var p = i.find("ul>li");
    p.click(function () {
      if (!$(this).hasClass("selected")) {
        $(this).removeClass("selected");
      } else {
        $(this).addClass("selected").siblings("li").removeClass("selected");
      }
    });
  });
});

// 弹出地址选择

$(document).ready(function ($) {
  var $ww = $(window).width();

  $(".theme-poptit .close,.btn-op .close").click(function () {
    $(document.body).css("overflow", "visible");
    $(".theme-login").removeClass("selected");
    $(".item-props-can").removeClass("selected");
    $(".theme-popover-mask").hide();
    $(".theme-popover").slideUp(200);
  });
});
</script>


<style scoped>
body,
button,
input,
select,
textarea {
  font: 12px/1.5 arial, "Lantinghei SC", "Microsoft Yahei";
}
.concent {
  overflow: hidden;
  width: 100%;
  max-width: 1000px;
  margin: 0px auto;
  margin-top: 60px;
}
.cart-table-th,
.td-sum {
  display: none;
}

/*title*/

.cart-table-th .th-chk {
  font-size: 12px;
  text-align: left;
  height: 50px;
  line-height: 50px;
}
.th-chk,
.td-chk {
  width: 40px;
}
.cart-table-th .th-chk .select-all {
  position: absolute;
  left: 0px;
  top: 0px;
  width: 80px;
  height: 50px;
  line-height: 50px;
}
.cart-table-th .th-chk .select-all span {
  position: absolute;
  top: 2px;
}

/*信息标题*/
.cart-table-th .th {
  float: left;
}
.cart-table-th {
  line-height: 50px;
  color: #3c3c3c;
}
.cart-table-th .th-item .td-inner {
  padding-left: 91px;
}

.th .td-inner {
  padding: 0px 0px 0px 10px;
}

/*操作标题*/
.th-op,
.td-op {
  width: 84px;
  padding: 0px 0px 0px 15px;
}
.td-oplist,
.th.th-oplist {
  width: 24%;
  padding: 0px 0px 0px 18px;
}
.th-oplist {
  padding-top: 5px;
}

/*广告-优惠信息*/
.bundle-hd {
  height: 28px;
  padding-top: 4px;
  position: relative;
  background: #eee;
}
.bundle-hd .icon-bd-title {
  position: absolute;
  bottom: -7px;
  left: 50%;
  width: 11px;
  margin-left: -6px;
  height: 6px;
  background-position: 0px -145px;
}
.bundle-hd .bd-promos {
  float: left;
  color: #6c6c6c;
  line-height: 22px;
}
.bundle-hd .bd-has-promo {
  color: #f40;
  float: left;
}
.bundle-hd .bd-promos .act-promo {
  margin-right: 20px;
  float: left;
}
.bundle.bundle-last {
  overflow: hidden;
  border-top: #f5f5f5 1px solid;
  border-bottom: #f5f5f5 1px solid;
  background: #fff;
}

.list-change {
  position: absolute;
  top: 4px;
  right: 0;
  width: 50px;
  text-align: center;
  border-left: 1px solid #f5f5f5;
  cursor: pointer;
}

/*主体*/
.item-content {
  width: 100%;
  overflow: hidden;
  position: relative;
  padding-bottom: 15px;
  border-top: #f5f5f5 1px solid;
}
.check {
  margin-top: 20px;
  margin-left: 10px;
  margin-right: 3px;
}
.item-content .td {
  float: left;
}

/*商品信息*/
.td-chk {
  width: 30px;
  position: absolute;
  top: 10px;
  left: 10px;
}
.td.td-item {
  float: left;
  width: 100%;
  padding-left: 30px;
}
/*图片*/
.td-item .item-info {
  margin: -3px 0px 0px 91px;
}
.item-content .item-pic a {
  text-align: center;
}
.item-content .item-pic {
  width: 80px;
  height: 80px;
  border: 1px solid #eee;
  float: left;
  overflow: hidden;
  margin-top: 20px;
  margin-left: 3px;
}
.td-item .item-basic-info {
  height: 40px;
  margin-top: 20px;
  text-align: left;
}
/*规格*/
.td.td-info {
  position: absolute;
  left: 0px;
  top: 55px;
  width: 100%;
  overflow: hidden;
  padding-left: 120px;
  line-height: 16px;
}
.td.td-info .item-props {
  width: 100%;
}
.sku-line {
  color: #9c9c9c;
  overflow: hidden;
}
.btn-edit-sku {
  display: none;
}
/*价格*/
.td.td-price {
  position: absolute;
  left: 120px;
  bottom: 10px;
}
.price-content {
  padding: 3px 0px 0px 0px;
  line-height: 1;
}
.item-content .price-original {
  color: #9c9c9c;
  text-decoration: line-through;
  position: absolute;
  bottom: 1px;
  left: 40px;
  font-size: 10px;
}
.item-content .price-now {
  color: #3c3c3c;
  font-weight: 600;
  font-size: 14px;
}
/*数量*/
.td.td-amount {
  position: absolute;
  bottom: 10px;
  right: 0;
}
.td.td-amount .sl {
  width: 30px;
  margin: 0px auto;
}
.td.td-amount .sl .min,
.td.td-amount .sl .add {
  display: none;
}
.td.td-amount .sl input.text_box {
  border: none;
}

/*操作*/
.td-op a {
  position: absolute;
  left: 5px;
  top: 80px;
}
.btn-fav {
  display: none;
}

/*全选、删除按钮*/
.float-bar-wrapper {
  position: fixed;
  overflow: hidden;
  bottom: 50px;
  width: 100%;
  background: #fff;
  border-top: 1px solid #e5e5e5;
}
.float-bar-wrapper .select-all {
  float: left;
  width: 65px;
  height: 50px;
  line-height: 50px;
  padding-left: 5px;
  margin-top: -3px;
  position: relative;
}
.float-bar-wrapper .select-all .cart-checkbox {
  display: inline-block;
  width: 15px;
  margin-right: 5px;
}
.float-bar-wrapper .select-all span {
  position: absolute;
  top: 2px;
}
.float-bar-wrapper .operations {
  float: left;
  line-height: 48px;
  height: 48px;
}
.float-bar-wrapper .operations a {
  margin-left: 5px;
  float: left;
}
.J_BatchFav,
.amount-sum {
  display: none;
}
.check-all.check {
  margin-top: 20px;
}
/*结算功能*/
.float-bar-right {
  float: right;
  position: absolute;
  right: 0px;
  top: 0px;
  z-index: 4;
  padding-left: 20px;
}
.amount-sum,
.price-sum,
.btn-area {
  float: left;
  height: 48px;
  color: #3c3c3c;
  line-height: 48px;
}

.amount-sum em {
  line-height: 50px;
  padding: 0px 5px;
}

.price-sum .price {
  color: #f40;
  font-weight: 400;
  font-size: 18px;
  line-height: 48px;
  font-family: Arial;
  vertical-align: middle;
  margin-right: 15px;
}
.btn-area {
  width: 80px;
  background: #f40;
  text-decoration: none;
  text-align: center;
}
.submit-btn {
  line-height: 48px;
  font-family: "Lantinghei SC", "Microsoft Yahei";
  font-size: 16px;
  color: #fff;
}

@media only screen and (min-width: 640px) {
  .concent {
    margin-top: 0;
  }
  .wp {
    overflow: hidden;
    border: #f5f5f5 2px solid;
  }
  #cartTable {
    background: #fff;
  }
  .bundle.bundle-last {
    border: #f5f5f5 1px solid;
  }
  .cart-table-th,
  .td-sum {
    display: block;
  }
  .th.th-op,
  .list-change {
    display: none;
  }

  .item-content {
    overflow: visible;
    height: 115px;
  }
  .bundle-hd {
    border-bottom: #ccc 1px dotted;
    padding: 5px 0px;
    height: auto;
    overflow: hidden;
    background: #eee;
  }
  .bundle-hd .bd-promos {
    margin-left: 35px;
  }
  .td.td-amount .sl {
    width: auto;
    margin-right: 0;
  }
  .td.td-amount .sl .min,
  .td.td-amount .sl .add {
    display: inline-block;
  }
  .td.td-amount .sl input.text_box {
    border: 1px solid #ddd;
  }
  /*布局 */
  .cart-table-th .th-item .td-inner {
    padding-left: 0px;
  }
  .th.th-item,
  .td.td-item,
  .td.td-info {
    width: 50%;
  }
  .th.th-item {
    margin-right: -40px;
  }
  /*价格*/
  .th.th-price,
  .td.td-price,
  .th.th-amount,
  .td.td-amount {
    position: static;
    width: 15%;
    text-align: center;
  }
  .td.td-price,
  .td.td-amount,
  .td.td-sum,
  .td.td-oplist {
    margin-top: 20px;
  }
  .item-content .price-original {
    position: static;
    font-size: 12px;
  }
  .price-content {
    padding-top: 0;
  }
  /*操作*/
  .th.th-sum,
  .td.td-sum {
    width: 20%;
    text-align: center;
  }
  .td-op a {
    position: absolute;
    top: -25px;
    left: 80%;
    width: 20%;
    text-align: center;
  }
  /*结算功能*/
  .float-bar-wrapper,
  .float-bar-right {
    position: static;
    border: #f5f5f5 1px solid;
    background: #eee;
  }
  .J_BatchFav,
  .amount-sum,
  .price-sum {
    display: block;
    margin-right: 10px;
  }
  .float-bar-wrapper {
    margin-top: 10px;
  }
  .footer {
    margin-top: 40px;
  }
}

@media only screen and (min-width: 1025px) {
  .item-content {
    overflow: hidden;
  }
  .td.td-item {
    width: 30%;
  }
  .td.td-info {
    width: 20%;
    position: static;
    padding-left: 0;
  }
  .td.td-info .item-props {
    position: static;
    text-align: center;
    padding-top: 17px;
    margin-top: 0;
  }
  .item-props.item-props-can {
    height: 100px;
    border: 1px dashed transparent;
  }
  /*价格*/
  .th.th-price,
  .td.td-price,
  .th.th-sum,
  .td.td-sum {
    width: 10%;
    text-align: center;
  }
  /*操作*/
  .th.th-amount,
  .td.td-amount,
  .th.th-op,
  .td.td-op {
    display: block;
    width: 15%;
    text-align: center;
  }
  .td-op {
    margin-top: 20px;
  }
  .td-op a {
    position: static;
    width: 100%;
  }
  .td-op .btn-fav {
    display: block;
  }
  .item-content .td .item-props-can {
    position: relative;
  }
  .item-content .td .item-props-can:hover,
  .item-content .td .item-props-can.selected {
    border-color: #f60;
    background: #fff none repeat scroll 0% 0%;
  }
  .item-props.item-props-can:hover .btn-edit-sku,
  .item-props.item-props-can .btn-edit-sku.selected {
    display: block;
    position: absolute;
    right: -1px;
    top: -1px;
    color: #fff;
    cursor: pointer;
    background: #f60 none repeat scroll 0% 0%;
    padding: 2px 4px 0px;
    width: auto;
    height: 16px;
    line-height: 1;
  }
}
/* CSS Document */
.paycont {
  margin-top: 60px;
  margin-bottom: 40px;
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
.am-text-lg {
  font-size: 18px;
}
.item-content {
  padding: 0px 10px;
}
input[type="text"] {
  -webkit-appearance: none;
  appearance: none;
  outline: none;
  -webkit-tap-highlight-color: rgba(0, 0, 0, 0);
  border-radius: 0;
}

.hidden {
  display: none !important;
}
.defaultAddr {
  display: block !important;
}
/*地址管理*/
.per-border {
  height: 4px;
  width: 100%;
  background: url(../../assets/images/peraddress.png) repeat-x;
}
.concent h3,
.logistics h3 {
  border-bottom: 2px solid #f1f1f1;
  margin-top: 10px;
}
h3 {
  font-size: 14px;
  font-weight: 700;
}
.control {
  display: none;
}
.address h3 {
  border-bottom: none;
}
.address li.user-addresslist {
  display: none;
  width: 100%;
  padding: 10px;
  position: relative;
  min-height: 80px;
}
.address-left {
  width: 90%;
  float: left;
  position: relative;
}
.user.DefaultAddr {
  font-size: 14px;
  font-weight: 700;
}
.address-right {
  float: right;
  margin-right: 5px;
  padding-top: 15px;
}
.deftip {
  position: absolute;
  top: 0px;
  right: 0px;
  padding: 0px 2px;
  text-decoration: none;
  opacity: 0.7;
  z-index: 3;
  background: #ccc none repeat scroll 0% 0%;
  color: #fff;
}

/*地址操作-编辑删除*/
.new-addr-btn {
  display: none;
  font-size: 12px;
  color: #282828;
  text-align: right;
  padding-right: 5px;
}
.new-addr-bar {
  padding: 0px 5px;
  vertical-align: top;
}

/*物流*/
.logistics li i {
  margin: 5px 10px;
}
.logistics li {
  border: 1px solid transparent;
  overflow: hidden;
}
.logistics li.selected {
  border-color: #f03726;
  position: relative;
}

.logistics li.selected span {
  position: absolute;
  width: 10px;
  height: 10px;
  font-size: 0;
  line-height: 0;
  right: 0px;
  bottom: 0px;
  background: url(../../assets/images/sys_item_selected.gif) no-repeat right
    bottom;
}
.op_express_delivery_hot li {
  width: 32%;
  float: left;
  display: block;
  cursor: pointer;
}
.op_express_delivery_hot i {
  background: transparent url(../../assets/images/kuaidi.png) no-repeat scroll
    0px 0px;
  display: inline-block;
  width: 36px;
  height: 36px;
  vertical-align: middle;
  overflow: hidden;
}

/*支付方式*/

.pay-way span.title {
  float: left;
  margin-top: 10px;
  margin-right: 10px;
}
.logistics .pay-list li {
  float: left;
  cursor: pointer;
  width: 32%;
}
.pay img {
  display: inline-block;
  width: 54px;
  height: 36px;
  overflow: hidden;
  margin: 5px auto;
}

/*订单界面改写*/
.td.td-item {
  padding-left: 0px;
}
.concent {
  margin-top: 0;
}
#cartTable {
  margin-bottom: 20px;
}
.item-content .item-pic {
  margin-left: 0px;
}
.td.td-info .item-props,
.td.td-price {
  left: 90px;
}
.pay-phone {
  position: relative;
  overflow: hidden;
  padding-bottom: 15px;
}
.bundle.bundle-last {
  border-bottom: none;
}

.td.td-amount {
  position: static;
  width: 100%;
}
.td.td-info {
  width: 100%;
  padding-left: 90px;
}
/*数量*/
.td.td-amount .amount-wrapper,
.td.td-oplist,
.order-extra,
.td.td-coupon,
.td.td-bonus {
  position: relative;
  width: 100%;
  padding: 8px 0px;
  border-top: 1px solid #f5f5f5;
}
.td.td-coupon {
  border-bottom: 1px solid #f5f5f5;
}
.td.td-bonus {
  border-top: 1px solid transparent;
  border-bottom: 1px solid #f5f5f5;
}
.td.td-amount .phone-title {
  display: inline;
  line-height: 24px;
  height: 24px;
}
.td.td-amount .sl {
  position: absolute;
  top: 3px;
  right: 0;
  width: auto;
}
.td.td-amount .sl .min,
.td.td-amount .sl .add {
  display: inline-block;
  width: 30px;
}
.td.td-amount .sl input.text_box {
  border: 1px solid #ddd;
}
/*运费、留言*/
.pay-total {
  padding: 0px 10px;
}
.td.td-oplist .pay-logis,
.td.td-coupon select,
.td.td-bonus select {
  position: absolute;
  top: 6px;
  right: 0;
}
.memo {
  position: relative;
}
.memo label {
  position: absolute;
  bottom: 1px;
  left: 0;
  line-height: 24px;
}
.memo-close {
  width: 100%;
  border: 2px solid #fff;
  padding-left: 60px;
  outline: none;
}

/*合计*/
.buy-point-discharge {
  font-size: 14px;
  font-weight: 700;
  padding: 10px 0px;
  text-align: right;
}
.pay-sum {
  color: #f64000;
  margin-left: 5px;
}

.pay-confirm.clearfix {
  width: 100%;
}
.box {
  float: left;
  width: 70%;
  height: 40px;
  line-height: 40px;
  font-size: 14px;
  text-align: right;
  padding-right: 10px;
}
.pay-address {
  display: none;
}
.submitOrder a {
  float: left;
  width: 30%;
  color: #fff;
  background: #f40;
  text-align: center;
  height: 40px;
  line-height: 40px;
  font-size: 14px;
}

.td.td-coupon select,
.td.td-bonus select {
  border-color: #ccc;
  line-height: 24px;
  height: 24px;
  margin-top: 4px;
}
.coupon-title,
.bonus-title {
  line-height: 24px;
  height: 24px;
}
.order-go {
  position: fixed;
  bottom: 0;
  width: 100%;
  background: #fff;
  border-top: 1px solid #f5f5f5;
}

.theme-popover {
  display: none;
}

@media only screen and (min-width: 640px) {
  .pay-way {
    float: right;
  }
  #payTable .th {
    border-top: none;
  }
  .th .td-inner {
    padding-left: 0px;
  }
  .wp {
    padding: 0px 10px;
    background: #f5f5f5;
  }
  /*地址操作*/
  .address h3 {
    float: left;
    border: none;
    margin-top: 20px;
  }
  .control {
    display: block;
    float: left;
    margin-left: 20px;
    margin-top: 10px;
  }
  .am-form-content {
    margin-left: 75px;
  }
  .am-form-label {
    width: 60px;
    float: left;
  }

  .paycont {
    max-width: 1000px;
    margin: 10px;
  }
  .paycont h3 {
    padding-bottom: 10px;
  }

  /*物流*/
  .op_express_delivery_hot li,
  .logistics .pay-list li {
    width: 18%;
    margin-right: 2%;
  }

  /*订单管理*/

  .td.td-info {
    width: 50%;
  }
  .pay-phone {
    overflow: visible;
    padding-bottom: 0px;
    margin-bottom: 0px;
  }
  .th.th-item,
  .td.td-amount .amount-wrapper .sl {
    text-align: center;
    width: auto;
  }
  .item-content .price-now {
    line-height: 18px;
    font-size: 12px;
    font-weight: 100;
  }

  .th.th-item {
    width: 50%;
    margin-right: 0;
  }
  .th.th-price,
  .td.td-price,
  .th.th-sum,
  .td.td-sum {
    width: 10%;
  }
  .th.th-amount,
  .td.td-amount {
    width: 20%;
  }
  .th.th-oplist,
  .td.td-oplist {
    width: 10%;
    text-align: center;
    padding-left: 0;
  }

  /*文字说明布局*/
  .td.td-amount .phone-title,
  .td.td-oplist .phone-title {
    display: none;
  }
  .td.td-oplist .pay-logis,
  .td.td-amount .sl,
  .td.td-coupon select,
  .td.td-bonus select {
    position: static;
  }
  .td.td-amount .amount-wrapper,
  .td.td-oplist {
    padding: 0px;
    border: none;
  }

  /*留言*/
  .pay-total {
    border: #f5f5f5 1px solid;
    overflow: hidden;
    padding: 10px;
  }
  .order-extra {
    border: none;
    float: left;
    width: 60%;
  }
  .memo label {
    position: static;
  }
  .memo-close {
    border: 1px solid #f5f5f5;
    padding-left: 10px;
    min-width: 280px;
    width: 80%;
  }
  /*优惠券*/
  .buy-agio {
    text-align: right;
    float: left;
    width: 40%;
  }
  .td.td-coupon,
  .td.td-bonus {
    border: none;
  }
  /*带个人信息的结算*/
  .box,
  .submitOrder a {
    float: right;
    width: auto;
    height: auto;
    padding: 10px 10px;
  }
  .pay-address {
    display: block;
  }
  .box {
    font-size: 12px;
    overflow: hidden;
    border: 2px solid #f40;
  }

  .order-go {
    clear: both;
    text-align: right;
    position: relative;
    margin-top: 10px;
    border: none;
  }
  .order-go .address-confirm .box {
    position: relative;
    float: right;
    z-index: 100;
    padding-right: 2%;
    padding-bottom: 10px;
    border: 1px solid #f50;
    font-family: tahoma;
    display: inline-block;
    right: 0;
    background-color: #fff0e8;
  }

  .submitOrder .go-btn-wrap {
    width: 100%;
    overflow: hidden;
    padding-top: 10px;
    margin-bottom: 10px;
  }
  .submitOrder .btn-go {
    display: block;
    padding: 0 26px;
    height: 36px;
    font: 400 18px/36px arial;
    font-size: 18px;
    background-color: #f50;
    color: #fff;
    text-align: center;
    cursor: pointer;
    outline: 0;
    z-index: 999;
  }
  .realPay {
    line-height: 16px;
    margin: 0px 0px 15px;
    position: relative;
  }
  .realPay .g_price span {
    font-size: 26px;
  }
  .price .style-large-bold-red {
    color: #ff4200;
    font: 700 26px tahoma;
  }
  .order-go .buy-footer-address .buy-line-title {
    color: #404040;
    font-weight: 700;
  }
  .td.td-coupon select,
  .td.td-bonus select {
    margin-top: 0;
  }

  .theme-popover-mask {
    z-index: 10000000;
    position: fixed;
    left: 0;
    top: 0;
    width: 100%;
    height: 100%;
    background: #000;
    opacity: 0.5;
    filter: alpha(opacity=50);
    -moz-opacity: 0.5;
    display: none;
  }
  .theme-popover {
    z-index: 10000009;
    position: fixed;
    bottom: 50%;
    left: 50%;
    width: 500px;
    height: 400px;
    margin-bottom: -200px;
    margin-left: -250px;
    display: none;
    background: #fff;
    overflow: hidden;
  }
  .theme-poptit {
    padding: 12px;
    position: relative;
  }
  .theme-poptit .close:hover {
    color: #444;
  }

  .theme-popover .am-form-content.address select {
    width: 32.3333%;
    margin-right: 1%;
    float: left;
  }
  .am-padding {
    padding: 10px 10px;
  }
  hr {
    margin: 5px 0px;
  }
  .am-form-group {
    margin-bottom: 10px;
  }

  .td.td-amount {
    margin-top: 15px;
  }
}

@media only screen and (min-width: 1025px) {
  .paycont {
    margin: 0px auto;
  }
  /*地址管理*/
  .address ul {
    margin-top: 10px;
  }
  .address li.user-addresslist {
    display: block;
    width: 255px;
    height: 150px;
    float: left;
    background: url(../../assets/images/peraddbg.png) no-repeat scroll 0% 0%;
    margin-right: 10px;
    padding: 10px;
  }
  .address li.user-addresslist.defaultAddr {
    background: url(../../assets/images/peraddressbg.png) no-repeat scroll 0% 0%;
  }
  .address-left {
    width: 100%;
    position: relative;
  }
  .address-right,
  .per-border {
    display: none;
  }
  .th .td-inner {
    padding-left: 0;
  }

  /*地址操作*/
  .new-mu_l2a {
    padding: 0px 12px 8px;
    display: block;
  }
  .new-mu_l2cw {
    padding-top: 10px;
    font-size: 14px;
    color: #6e6e6e;
  }
  .new-addr-btn {
    display: block;
    position: absolute;
    bottom: 25px;
    right: 10px;
  }
  .new-addr-bar {
    padding: 0px 5px;
    vertical-align: top;
  }

  .td.td-item,
  .td.td-info {
    width: 50%;
  }
  .td.td-info {
    position: absolute;
    margin-top: 0px;
  }
  .td.td-info .item-props {
    text-align: left;
    padding-top: 0px;
  }
}
@charset "utf-8";
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

.am-btn {
  font-size: 12px;
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
}

a:link,
a:visited,
a:hover {
  text-decoration: none;
  outline: none;
}
/*所有超链接不要下划线*/

*,
*:after,
*:before {
  -webkit-box-sizing: border-box;
  -moz-box-sizing: border-box;
  -o-box-sizing: border-box;
  box-sizing: border-box;
}
/*任何标签、包括它前面、后面生成的内容都不要影响盒子的边框*/

.clear {
  clear: both;
}

img,
input {
  vertical-align: middle;
}
a {
  color: #000;
  text-decoration: none;
}

.spatic {
  width: 100%;
  height: 16px;
}
h5 {
  float: right;
  color: #666;
  padding-right: 20px;
}

input.add,
input.min {
  width: 15px;
}
.last {
  border-right: none !important;
}
/*选项卡样式定义*/
.am-nav-tabs,
.am-tabs-bd {
  border-color: transparent;
}
.am-nav-tabs > li.am-active > a,
.am-nav-tabs > li.am-active > a:hover,
.am-nav-tabs > li.am-active > a:focus,
.am-nav-tabs > li > a:hover,
.am-nav-tabs > li > a:focus {
  color: #555555;
  background: none;
  border-color: transparent;
  cursor: default;
}
.am-nav-tabs > li {
  border-bottom: 2px solid transparent;
}
.am-nav-tabs > li.am-active {
  border-bottom: 2px solid #f03726;
}
.am-tabs-nav li {
  max-width: 216px;
  height: 36px;
  font-size: 16px;
  line-height: 36px;
}
.am-tabs-nav li a,
.am-tabs-nav li.am-active a {
  cursor: pointer;
}

/*选项卡样式*/
.am-nav-tabs > li.am-active span {
  color: #e4393c;
  font-size: 16px;
}
.am-nav-tabs > li span {
  font-size: 16px;
  font-weight: 700;
}

/*浮动框*/
.nav.white {
  position: fixed;
  top: 0;
  width: 100%;
  z-index: 1099;
  margin: 0px auto;
  background: #fff;
}
.nav.white .logo {
  float: left;
  height: 41px;
  width: 70px;
  margin: 6px auto;
}
.logoBig {
  display: none;
}
.logo img {
  width: 100%;
}

/*搜索框*/
.search-bar {
  height: 41px;
  margin: 8px 20px 0 75px;
}
.search-bar form {
  border: 2px solid #f03726;
  max-width: 670px;
}
.search-bar input {
  padding-left: 5px;
  height: 32px;
  width: 78%;
  outline: none;
  font-size: 12px;
  border: none;
}
#ai-topsearch {
  width: 20%;
  height: 32px;
  border: none;
  float: right;
  background: #f03726 none repeat scroll 0% 0%;
  color: #f5f5f2;
  font-size: 14px;
  cursor: pointer;
  border-radius: 0px 0px;
}

/* 分类*/
.long-title,
.nav-cont {
  display: none;
}

/*侧边导航*/
.mui-mbar-tabs {
  display: none;
}

.header {
  display: none;
  max-width: 1000px;
  margin: 0px auto;
  font-size: 12px;
}

.footer-bd {
  display: none;
}
.footer {
  text-align: center;
  border-top: 2px solid #f8f8f8;
  margin-top: 20px;
  padding-top: 5px;
  margin-bottom: 60px;
}
.footer-hd {
  display: block;
}
.tip {
  display: none;
}

.navCir {
  position: fixed;
  bottom: 0px;
  width: 100%;
  z-index: 999;
  background: #fff;
}
.navCir li {
  width: 25%;
  padding: 5px;
  background: #fff;
  border-top: 1px solid #f5f5f5;
  float: left;
  text-align: center;
  font-size: 14px;
}
.navCir li i {
  display: block;
  font-size: 18px;
}
.navCir li.active a {
  color: #f03726;
}

@media only screen and (min-width: 640px) {
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
    font-size: 14px;
  }

  .nav.white {
    background: none;
  }
  .header {
    display: block;
    height: 35px;
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

  .nav.white .logo {
    display: none;
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
  .search-bar {
    height: 51px;
    margin: 0px 50px 0 120px;
    padding-left: 5%;
  }
  #ai-topsearch {
    height: 46px;
  }
  .search-bar input {
    width: 80%;
    height: 46px;
  }
  .my-cart a {
    display: block;
    margin-top: 5px;
  }
  .classified {
    display: none;
  }
  .navCir {
    display: none;
  }
  .nav.white {
    position: relative;
    top: 0px;
    z-index: 0;
  }
  #ai-topsearch {
    font-size: 18px;
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
  .header,
  .nav.white {
    padding-right: 40px;
  }
  .bloglist {
    margin-top: 0px;
  }
  .shopMain {
    margin: 0px 5px;
  }
  /*选项卡样式*/
  .am-nav-tabs > li span {
    font-size: 16px;
    padding: 5px 15px;
  }
}
@media only screen and (min-width: 1025px) {
  .mui-mbar-tabs {
    display: block;
  }
  .nav.white {
    padding-left: 0px;
    max-width: 1000px;
    margin: 0px auto;
  }
  .nav.white .logo {
    display: none;
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

  .my-cart {
    display: none;
    right: 10%;
    top: 20px;
  }
  .shopNavfloat {
    display: block;
    position: fixed;
    bottom: 0px;
    left: 30px;
  }
  .shopMain {
    margin: 0px 40px 0px 5px;
  }
  .shopCon li {
    width: 20%;
    padding: 10px;
  }
  .search-bar input {
    height: 46px;
  }
  .search-bar {
    margin: 0px auto;
  }
  .tip {
    display: block;
  }

  /*分类*/
  .nav-table {
    max-width: 1000px;
    margin: 0px auto;
    height: 45px;
    position: relative;
    overflow: hidden;
  }
  .all-goods {
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
    position: absolute;
    top: 180px;
    z-index: 5;
  }
}

@media only screen and (min-width: 1260px) {
  .am-container {
    max-width: 1200px;
  }
  .footer {
    max-width: 1200px;
    margin: auto;
  }
  /*分类*/
  .nav-table {
    max-width: 1200px;
  }
  .long-title {
    width: 180px;
  }
  .nav-cont {
    padding-left: 180px;
  }
}

/*侧边信息栏*/
.tip {
  position: fixed;
  top: 0px;
  right: 0px;
  background-color: #e1e1e1;
  min-height: 100%;
  z-index: 1000;
}
#sidebar {
  padding-top: 120px;
  width: 35px;
  position: absolute;
  right: 0;
  background-color: #2b2b2b;
  min-height: 100%;
  z-index: 100;
  color: #fff;
}

#content {
  width: 800px;
  margin: 0 auto;
  height: 400px;
}
.item {
  text-align: center;
  cursor: pointer;
  position: relative;
  padding-bottom: 3px;
}
.item span,
.quick_toggle li span {
  display: block;
  line-height: 38px;
  width: 35px;
  height: 38px;
  background: url(../../assets/images/ibar_sprites.png) no-repeat;
}
/*图标定位*/
.item .setting {
  position: absolute;
  top: 10px;
  left: 10px;
  width: 18px;
  height: 19px;
  background-position: 0 0;
}
.item:hover .setting {
  background-position: -33px 0;
}
.item .message {
  position: absolute;
  top: 10px;
  left: 8px;
  width: 22px;
  height: 19px;
  background-position: 0px -29px;
}
.item:hover .message {
  background-position: -33px -29px;
}
.item .view {
  position: absolute;
  width: 18px;
  height: 18px;
  background-position: 0 -57px;
  top: 10px;
  left: 10px;
}
.item:hover .view {
  background-position: -33px -57px;
}
.item .zuji {
  position: absolute;
  width: 11px;
  height: 24px;
  background-position: -4px -110px;
  top: 8px;
  left: 12px;
}
.item:hover .zuji {
  background-position: -36px -110px;
}

.item span.wdsc,
.item span.chongzhi {
  background: none;
}

.item:hover,
.quick_toggle li:hover {
  background: #ed145b;
}
.item p {
  font-size: 12px;
  width: 16px;
  margin: 0px auto;
  padding-bottom: 10px;
}
.item,
.nav-content {
  font-size: 12px;
}
.ibar_login_box {
  width: 267px;
  height: 185px;
  padding: 10px;
  background: #fff;
  box-shadow: 0 0 5px rgba(0, 0, 0, 0.4);
  border-radius: 5px 0 0 5px;
  border-left: 1px solid #ccc0;
  border-top: 1px solid #ccc0;
  border-bottom: 1px solid #ccc0;
  z-index: 3;
  position: absolute;
  top: 0px;
  left: -270px;
  display: none;
}

#shopCart {
  overflow: hidden;
}
p.cart_num {
  width: 21px;
  height: 21px;
  display: block;
  border-radius: 50%;
  background: #ed145b none repeat scroll 0% 0%;
  text-align: center;
  line-height: 21px;
  cursor: pointer;
  color: #fff;
  margin-bottom: 10px;
}
.item:hover p.cart_num {
  background: #fff;
  color: #ed145b;
}
/*小图标定位*/

.quick_toggle {
  position: absolute;
  bottom: 0;
  left: 0;
  width: 40px;
  background: #2b2b2b;
  z-index: 1;
}
.item a,
.quick_toggle a {
  display: block;
  width: 40px;
  height: 38px;
  cursor: pointer;
  position: relative;
  overflow: hidden;
}
.quick_toggle span {
  position: absolute;
  top: 12px;
  left: 12px;
  background: url(../../assets/images/ibar_sprites.png) no-repeat;
}
.quick_toggle .kfzx {
  background-position: 0 -175px;
}
.quick_toggle li:hover .kfzx {
  background-position: -33px -175px;
}
.quick_toggle .mpbtn_qrcode {
  background-position: 0 -302px;
  position: absolute;
  top: 12px;
  left: 10px;
}
.quick_toggle .top {
  background-position: 0 -201px;
  position: absolute;
  top: 12px;
  left: 10px;
}

/*展开内容项布局*/
.ia-head-list .num {
  font-size: 16px;
  height: 26px;
  font-family: arial;
}
.ia-head-list .pl {
  width: 60px;
  border-right: dashed 1px #ccc;
  height: 47px;
  margin-top: 10px;
  margin-left: 6px;
  text-align: center;
  float: left;
}
.pl.money {
  border-right: none;
}
.ia-head-list {
  height: 66px;
  width: 200px;
  background: #f3f3f3;
  overflow: hidden;
  zoom: 1;
  margin-top: 15px;
  color: #4a4a4a;
}
/*头像*/
.ibar_login_box .avatar_imgbox {
  width: 100px;
  height: 100px;
  border-radius: 50%;
  overflow: hidden;
  float: left;
}
.status_login .user_info {
  overflow: hidden;
  color: #333;
  padding-top: 30px;
  line-height: 24px;
  width: 140px;
  float: left;
}
.ibar_login_box .login_btnbox {
  width: 200px;
  height: 79px;
  border-top: 1px dotted #d5d5d5;
  overflow: hidden;
  padding-top: 15px;
  clear: both;
  margin: 0px auto;
}
.ibar_login_box .login_btnbox a {
  width: 94px;
  height: 30px;
  line-height: 30px;
  text-align: center;
  border: 1px solid;
  color: #333;
  text-decoration: none;
  float: left;
  background-position: 0 -408px;
  background-repeat: repeat-x;
  border-color: #e9e9e9;
}

.mp_tooltip {
  height: 38px;
  line-height: 38px;
  width: 92px;
  position: absolute;
  z-index: 2;
  left: -121px;
  top: 0;
  background: #2b2b2b;
  color: #d8d8d8;
  text-align: center;
  display: block;
  visibility: hidden;
  font-size: 12px;
}
.icon_arrow_white {
  position: absolute;
  right: -5px;
  top: 15px;
  width: 5px;
  height: 9px;
  background: url(../../assets/images/ibar_sprites.png) no-repeat;
  background-position: 0 -253px;
}
.icon_arrow_right_black {
  position: absolute;
  right: -5px;
  top: 15px;
  width: 5px;
  height: 9px;
  background: url(../../assets/images/ibar_sprites.png) no-repeat;
  background-position: 0px -234px;
  overflow: hidden;
}

.mp_qrcode {
  padding: 10px;
  width: 148px;
  height: 150px;
  top: -50px;
  background: #fff;
  box-shadow: 0 0 5px rgba(0, 0, 0, 0.4);
  border-radius: 5px 0 0 5px;
  border: 1px solid #ccc;
  z-index: 3;
  position: absolute;
  left: -154px;
  display: none;
}
.mp_qrcode .icon_arrow_white {
  top: 105px;
}
.nav-content {
  position: absolute;
  min-height: 100%;
  width: 200px;
  background-color: #fff;
  z-index: 99;
  text-align: center;
  right: -165px;
  border-radius: 5px 0 0 5px;
  border: 1px solid #999;
  padding-top: 15px;
}

.mp_qrcode img {
  width: 100%;
  height: auto;
}

.am-article-title.blog-title {
  font-size: 24px;
  line-height: 1.15;
  font-weight: normal;
  margin: 10px 0px 20px;
}
.blog-content p {
  margin: 0 0 1.6rem 0;
  font-size: 14px;
}
</style>
<style scoped>
/* 自定义样式，覆盖追加append-to-body，样式失效 */
.el-dialog-s {
  z-index: 11;
}
/* 自定义样式，覆盖追加append-to-body，样式失效 */
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
  border-bottom: 1px solid #dcdcdc;
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
  width: 119px;
  height: 45px;
  line-height: 45px;
  border: none;
  outline: none;
  background-color: red;
}

.settle_button:disabled {
  background-color: silver;
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
  border: 1px solid #dcdcdc;
  background: #f5f5f5;
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
  border: 1px dashed #f00;
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