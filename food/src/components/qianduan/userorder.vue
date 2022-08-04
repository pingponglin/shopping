<template>
  <div>
    <div class="center">
      <div class="col-main">
        <div class="main-wrap">
          <div class="user-order">
            <!--标题 -->
            <div class="am-cf am-padding">
              <div class="am-fl am-cf">
                <strong class="am-text-danger am-text-lg">订单管理</strong> /
                <small>Order</small>
              </div>
            </div>
            <hr />
            <div class="am-tabs am-tabs-d2 am-margin" data-am-tabs>
              <ul class="am-avg-sm-5 am-tabs-nav am-nav am-nav-tabs">
                <li class="am-active"><a href="#tab1">所有订单</a></li>
                <li><a href="#tab2">待付款</a></li>
                <li><a href="#tab3">待发货</a></li>
                <li><a href="#tab4">待收货</a></li>
                <li><a href="#tab5">待评价</a></li>
              </ul>

              <div class="am-tabs-bd">
                <div class="am-tab-panel am-fade am-in am-active" id="tab1">
                  <div class="order-top">
                    <div class="th th-item">
                      <td class="td-inner" style="position: relative;left: 81px;">商品</td>
                    </div>
                    <div class="th th-price">
                      <td class="td-inner">单价</td>
                    </div>
                    <div class="th th-number">
                      <td class="td-inner">数量</td>
                    </div>
                    <div class="th th-operation">
                      <td class="td-inner" style="position: relative;left: 30px;">商品操作</td>
                    </div>
                    <div class="th th-amount">
                      <td class="td-inner">实付款</td>
                    </div>
                    <div class="th th-status">
                      <td class="td-inner">交易状态</td>
                    </div>
                    <div class="th th-change">
                      <td class="td-inner">交易操作</td>
                    </div>
                  </div>

                  <div class="order-main" >
                    <div class="order-list">
                       <!--待付款-->
                      <div class="order-status3">
                          <div v-for="fahuo in orderfuka" :key="fahuo.Orderid">
                        <div class="order-title" style="background-color: #F5F5F5;">
                          <div class="dd-num">
                            订单编号：<a href="javascript:;">{{fahuo.Ordername}}</a>
                          </div>
                          <span>成交时间：{{fahuo.Ordertime | dateFormat}}</span>
                          <!--    <em>店铺：小桔灯</em>-->
                        </div>
                        <div class="order-content">
                          <div class="order-left">
                            <ul class="item-list">
                              <li class="td td-item">
                                <div class="item-pic">
                                  <a href="#" class="J_MakePoint">
                                    <img
                                      :src="'http://81.68.132.153:7070/img/'+fahuo.Good.GoodImage"
                                      class="itempic J_ItemImg"
                                    />
                                  </a>
                                </div>
                                <div class="item-info">
                                  <div class="item-basic-info">
                                    <a href="#">
                                      <p>
                                        {{fahuo.Good.GoodfuName}}
                                      </p>
                                      <p class="info-little">
                                         类型：{{fahuo.Goodtypetwo.Goodtypetwoname}}
                                      </p>
                                    </a>
                                  </div>
                                </div>
                              </li>
                              <li class="td td-price">
                                <div class="item-price">￥{{fahuo.Good.GoodPrcieper}}.00</div>
                              </li>
                              <li class="td td-number">
                                <div class="item-number"><span>×</span>{{fahuo.Ordernum}}</div>
                              </li>
                              <li class="td td-operation">
                                <div class="item-operation">
                                </div>
                              </li>
                            </ul>
                          </div>
                          <div class="order-right">
                            <li class="td td-amount">
                              <div class="item-amount">
                                合计：￥{{fahuo.Ordersum}}
                              </div>
                            </li>
                            <div class="move-right">
                              <li class="td td-status">
                                <div class="item-status">
                                  <p class="Mystatus">等待买家付款</p>
                                  <p class="order-info">
                                    <a href="#" @click="quxiao(fahuo.Orderid)">取消订单</a>
                                  </p>
                                </div>
                              </li>
                              <li class="td td-change">
                                <div class="am-btn am-btn-danger anniu" @click="gouma(fahuo)" style="width: 91px;height: 38px;text-align: center;line-height: 36px;">
                                  一键支付
                                </div>
                              </li>
                            </div>
                          </div>
                        </div>
                        </div>
                      </div>
                      <!--待发货-->
                      <div class="order-status2">
                          <div v-for="fahuo in orderfahuo" :key="fahuo.Orderid">
                        <div class="order-title" style="background-color: #F5F5F5;">
                          <div class="dd-num">
                            订单编号：<a href="javascript:;">{{fahuo.Ordername}}</a>
                          </div>
                          <span>成交时间：{{fahuo.Ordertime | dateFormat}}</span>
                          <!--    <em>店铺：小桔灯</em>-->
                        </div>
                        <div class="order-content">
                          <div class="order-left">
                            <ul class="item-list">
                              <li class="td td-item">
                                <div class="item-pic">
                                  <a href="#" class="J_MakePoint">
                                    <img
                                      :src="'http://81.68.132.153:7070/img/'+fahuo.Good.GoodImage"
                                      class="itempic J_ItemImg"
                                    />
                                  </a>
                                </div>
                                <div class="item-info">
                                  <div class="item-basic-info">
                                    <a href="#">
                                      <p>
                                        {{fahuo.Good.GoodfuName}}
                                      </p>
                                      <p class="info-little">
                                         类型：{{fahuo.Goodtypetwo.Goodtypetwoname}}
                                      </p>
                                    </a>
                                  </div>
                                </div>
                              </li>
                              <li class="td td-price">
                                <div class="item-price">￥{{fahuo.Good.GoodPrcieper}}.00</div>
                              </li>
                              <li class="td td-number">
                                <div class="item-number"><span>×</span>{{fahuo.Ordernum}}</div>
                              </li>
                              <li class="td td-operation">
                                <div class="item-operation">
                                  <a href="#" @click="ordertuik(fahuo.Orderid)">退款</a>
                                </div>
                              </li>
                            </ul>
                          </div>
                          <div class="order-right">
                            <li class="td td-amount">
                              <div class="item-amount">
                                合计：￥{{fahuo.Ordersum}}
                              </div>
                            </li>
                            <div class="move-right">
                              <li class="td td-status">
                                <div class="item-status">
                                  <p class="Mystatus">买家已付款</p>
                                  <p class="order-info">
                                    <a href="#" @click="dingxiangqi(fahuo.Orderid)">订单详情</a>
                                  </p>
                                </div>
                              </li>
                              <li class="td td-change">
                                <div class="am-btn am-btn-danger anniu" @click="quer(fahuo.Orderid)" style="width: 91px;height: 38px;text-align: center;line-height: 36px;">
                                  提醒发货
                                </div>
                              </li>
                            </div>
                          </div>
                        </div>
                        </div>
                      </div>
                       <!--待收货-->
                      <div class="order-status3">
                          <div v-for="fahuo in orderdaishouhuo" :key="fahuo.Orderid">
                        <div class="order-title" style="background-color: #F5F5F5;">
                          <div class="dd-num">
                            订单编号：<a href="javascript:;">{{fahuo.Ordername}}</a>
                          </div>
                          <span>成交时间：{{fahuo.Ordertime | dateFormat}}</span>
                          <!--    <em>店铺：小桔灯</em>-->
                        </div>
                        <div class="order-content">
                          <div class="order-left">
                            <ul class="item-list">
                              <li class="td td-item">
                                <div class="item-pic">
                                  <a href="#" class="J_MakePoint">
                                    <img
                                      :src="'http://81.68.132.153:7070/img/'+fahuo.Good.GoodImage"
                                      class="itempic J_ItemImg"
                                    />
                                  </a>
                                </div>
                                <div class="item-info">
                                  <div class="item-basic-info">
                                    <a href="#">
                                      <p>
                                        {{fahuo.Good.GoodfuName}}
                                      </p>
                                      <p class="info-little">
                                         类型：{{fahuo.Goodtypetwo.Goodtypetwoname}}
                                      </p>
                                    </a>
                                  </div>
                                </div>
                              </li>
                              <li class="td td-price">
                                <div class="item-price">￥{{fahuo.Good.GoodPrcieper}}.00</div>
                              </li>
                              <li class="td td-number">
                                <div class="item-number"><span>×</span>{{fahuo.Ordernum}}</div>
                              </li>
                              <li class="td td-operation">
                                <div class="item-operation">
                                  <a href="#" @click="ordertuik(fahuo.Orderid)">退款/退货</a>
                                </div>
                              </li>
                            </ul>
                          </div>
                          <div class="order-right">
                            <li class="td td-amount">
                              <div class="item-amount">
                                合计：￥{{fahuo.Ordersum}}
                              </div>
                            </li>
                            <div class="move-right">
                              <li class="td td-status">
                               <div class="item-status">
                                  <p class="Mystatus">卖家已发货</p>
                                  <p class="order-info">
                                    <a href="#" @click="dingxiangqi(fahuo.Orderid)">订单详情</a>
                                  </p>
                                  <p class="order-info">
                                    <a href="#" @click="faUserdzhu(fahuo.Orderid)">查看物流</a>
                                  </p>
                                </div>
                              </li>
                              <li class="td td-change" @click="qurshouhuo(fahuo.Orderid)">
                                <div class="am-btn am-btn-danger anniu" style="width: 91px;height: 38px;text-align: center;line-height: 36px;">
                                  确认收货
                                </div>
                              </li>
                            </div>
                          </div>
                        </div>
                        </div>
                      </div>
                       <!--待评价-->
                      <div class="order-status2">
                          <div v-for="fahuo in orderpingjia" :key="fahuo.Orderid">
                        <div class="order-title" style="background-color: #F5F5F5;">
                          <div class="dd-num">
                            订单编号：<a href="javascript:;">{{fahuo.Ordername}}</a>
                          </div>
                          <span>成交时间：{{fahuo.Ordertime | dateFormat}}</span>
                          <!--    <em>店铺：小桔灯</em>-->
                        </div>
                        <div class="order-content">
                          <div class="order-left">
                            <ul class="item-list">
                              <li class="td td-item">
                                <div class="item-pic">
                                  <a href="#" class="J_MakePoint">
                                    <img
                                      :src="'http://81.68.132.153:7070/img/'+fahuo.Good.GoodImage"
                                      class="itempic J_ItemImg"
                                    />
                                  </a>
                                </div>
                                <div class="item-info">
                                  <div class="item-basic-info">
                                    <a href="#">
                                      <p>
                                        {{fahuo.Good.GoodfuName}}
                                      </p>
                                      <p class="info-little">
                                         类型：{{fahuo.Goodtypetwo.Goodtypetwoname}}
                                      </p>
                                    </a>
                                  </div>
                                </div>
                              </li>
                              <li class="td td-price">
                                <div class="item-price">￥{{fahuo.Good.GoodPrcieper}}.00</div>
                              </li>
                              <li class="td td-number">
                                <div class="item-number"><span>×</span>{{fahuo.Ordernum}}</div>
                              </li>
                              <li class="td td-operation">
                                <div class="item-operation">
                                </div>
                              </li>
                            </ul>
                          </div>
                          <div class="order-right">
                            <li class="td td-amount">
                              <div class="item-amount">
                                合计：￥{{fahuo.Ordersum}}
                              </div>
                            </li>
                            <div class="move-right">
                              <li class="td td-status">
                                <div class="item-status">
                                  <p class="Mystatus">卖家已发货</p>
                                  <p class="order-info">
                                    <a href="#" @click="dingxiangqi(fahuo.Orderid)">订单详情</a>
                                  </p>
                                  <p class="order-info">
                                    <a href="#"  @click="faUserdzhu(fahuo.Orderid)">查看物流</a>
                                  </p>
                                </div>
                              </li>
                              <li class="td td-change" @click="pingjias(fahuo.Orderid)">
                                <div class="am-btn am-btn-danger anniu" style="width: 91px;height: 38px;text-align: center;line-height: 36px;">
                                  评价商品
                                </div>
                              </li>
                            </div>
                          </div>
                        </div>
                        </div>
                      </div>
                      <!--交易成功-->
                      <div class="order-status5">
                        <div v-for="yiwangcheng in orderyiwangceng" :key="yiwangcheng.Orderid">
                        <div class="order-title" style="background-color: #F5F5F5;">
                          <div class="dd-num">
                            订单编号：<a href="javascript:;">{{yiwangcheng.Ordername}}</a>
                          </div>
                          <span>成交时间：{{yiwangcheng.Ordertime | dateFormat }}</span>
                          <!--    <em>店铺：小桔灯</em>-->
                        </div>
                        <div class="order-content">
                          <div class="order-left">
                            <ul class="item-list">
                              <li class="td td-item">
                                <div class="item-pic">
                                  <a href="#" class="J_MakePoint">
                                    <img
                                      :src="'http://81.68.132.153:7070/img/'+yiwangcheng.Good.GoodImage"
                                      class="itempic J_ItemImg"
                                    />
                                  </a>
                                </div>
                                <div class="item-info">
                                  <div class="item-basic-info">
                                    <a href="#">
                                      <p>
                                        {{yiwangcheng.Good.GoodfuName}}
                                      </p>
                                      <p class="info-little">
                                        类型：{{yiwangcheng.Goodtypetwo.Goodtypetwoname}}
                                      </p>
                                    </a>
                                  </div>
                                </div>
                              </li>
                              <li class="td td-price">
                                <div class="item-price">{{yiwangcheng.Good.GoodPrcieper}}</div>
                              </li>
                              <li class="td td-number">
                                <div class="item-number"><span>×</span>{{yiwangcheng.Ordernum}}</div>
                              </li>
                              <li class="td td-operation">
                                <div class="item-operation">
                                   <a href="#" @click="ordertuik(yiwangcheng.Orderid)">退款/退货</a>
                                </div>
                              </li>
                            </ul>
                          </div>
                          <div class="order-right">
                            <li class="td td-amount">
                              <div class="item-amount">
                                合计：￥{{yiwangcheng.Ordersum}}
                              </div>
                            </li>
                            <div class="move-right">
                              <li class="td td-status">
                                <div class="item-status">
                                  <p class="Mystatus">交易成功</p>
                                  <p class="order-info">
                                    <a href="#" @click="dingxiangqi(yiwangcheng.Orderid)">订单详情</a>
                                  </p>
                                  <p class="order-info">
                                    <a href="#" @click="faUserdzhu(yiwangcheng.Orderid)">查看物流</a>
                                  </p>
                                </div>
                              </li>
                              <li class="td td-change" @click="shanchuorder(yiwangcheng.Orderid)">
                                <div class="am-btn am-btn-danger anniu" style="width: 91px;height: 38px;text-align: center;line-height: 36px;">
                                  删除订单
                                </div>
                              </li>
                            </div>
                          </div>
                        </div></div>
                      </div>
                      
                    </div>
                  </div>
                </div>
                <!-- 待付款 -->
                <div class="am-tab-panel am-fade" id="tab2">
                  <div class="order-top">
                    <div class="th th-item">
                      <td class="td-inner"  style="position: relative;left: 81px;">商品</td>
                    </div>
                    <div class="th th-price">
                      <td class="td-inner">单价</td>
                    </div>
                    <div class="th th-number">
                      <td class="td-inner">数量</td>
                    </div>
                    <div class="th th-operation">
                      <td class="td-inner" style="position: relative;left: 30px;">商品操作</td>
                    </div>
                    <div class="th th-amount">
                      <td class="td-inner">合计</td>
                    </div>
                    <div class="th th-status">
                      <td class="td-inner">交易状态</td>
                    </div>
                    <div class="th th-change">
                      <td class="td-inner">交易操作</td>
                    </div>
                  </div>

                  <div class="order-main">
                    <div class="order-list" v-for="fuka in orderfuka" :key="fuka.Orderid">
                      <div class="order-status1">
                        <div class="order-title" style="background-color: #F5F5F5;">
                          <div class="dd-num">
                            订单编号：<a href="javascript:;">{{fuka.Ordername}}</a>
                          </div>
                          <span>成交时间：{{fuka.Ordertime | dateFormat }}</span>
                          <!--    <em>店铺：小桔灯</em>-->
                        </div>
                        <div class="order-content">
                          <div class="order-left">
                            <ul class="item-list">
                              <li class="td td-item">
                                <div class="item-pic">
                                  <a href="#" class="J_MakePoint">
                                    <img
                                      :src="'http://81.68.132.153:7070/img/'+fuka.Good.GoodImage"
                                      class="itempic J_ItemImg"
                                    />
                                  </a>
                                </div>
                                <div class="item-info">
                                  <div class="item-basic-info">
                                    <a href="#">
                                      <p>
                                       {{fuka.Good.GoodfuName}}
                                      </p>
                                      <p class="info-little">
                                        类型:{{fuka.Goodtypetwo.Goodtypetwoname}}
                                      </p>
                                    </a>
                                  </div>
                                </div>
                              </li>
                              <li class="td td-price">
                                <div class="item-price"> ￥{{fuka.Good.GoodPrcieper}}</div>
                              </li>
                              <li class="td td-number">
                                <div class="item-number"><span>×</span>{{fuka.Ordernum}}</div>
                              </li>
                              <li class="td td-operation">
                                <div class="item-operation">
                                 
                                </div>
                              </li>
                            </ul>

                          </div>
                          <div class="order-right">
                            <li class="td td-amount">
                              <div class="item-amount">
                                合计：￥{{fuka.Ordersum}}.00
                              </div>
                            </li>
                            <div class="move-right">
                              <li class="td td-status">
                                <div class="item-status">
                                  <p class="Mystatus">等待买家付款</p>
                                  <p class="order-info">
                                    <a href="#" @click="quxiao(fuka.Orderid)">取消订单</a>
                                  </p>
                                </div>
                              </li>
                              <li class="td td-change">
                                <a href="#" @click="gouma(fuka)">
                                  <div class="am-btn am-btn-danger anniu" style="width: 91px;height: 38px;text-align: center;line-height: 36px;">
                                    一键支付
                                  </div></a
                                >
                              </li>
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
                <!-- 待发货 -->
                <div class="am-tab-panel am-fade" id="tab3">
                  <div class="order-top">
                    <div class="th th-item">
                      <td class="td-inner" style="position: relative;left: 81px;">商品</td>
                    </div>
                    <div class="th th-price">
                      <td class="td-inner">单价</td>
                    </div>
                    <div class="th th-number">
                      <td class="td-inner">数量</td>
                    </div>
                    <div class="th th-operation">
                      <td class="td-inner" style="position: relative;left: 30px;">商品操作</td>
                    </div>
                    <div class="th th-amount">
                      <td class="td-inner">合计</td>
                    </div>
                    <div class="th th-status">
                      <td class="td-inner">交易状态</td>
                    </div>
                    <div class="th th-change">
                      <td class="td-inner">交易操作</td>
                    </div>
                  </div>

                  <div class="order-main">
                    <div class="order-list" v-for="fahuo in orderfahuo" :key="fahuo.Orderid">
                      <div class="order-status2">
                        <div class="order-title" style="background-color: #F5F5F5;">
                          <div class="dd-num">
                            订单编号：<a href="javascript:;">{{fahuo.Ordername}}</a>
                          </div>
                          <span>成交时间：{{fahuo.Ordertime | dateFormat }}</span>
                          <!--    <em>店铺：小桔灯</em>-->
                        </div>
                        <div class="order-content">
                          <div class="order-left">
                            <ul class="item-list">
                              <li class="td td-item">
                                <div class="item-pic">
                                  <a href="#" class="J_MakePoint">
                                    <img
                                       :src="'http://81.68.132.153:7070/img/'+fahuo.Good.GoodImage"
                                      class="itempic J_ItemImg"
                                    />
                                  </a>
                                </div>
                                <div class="item-info">
                                  <div class="item-basic-info">
                                    <a href="#">
                                      <p>
                                        {{fahuo.Good.GoodfuName}}
                                      </p>
                                      <p class="info-little">
                                        类型:{{fahuo.Goodtypetwo.Goodtypetwoname}}
                                      </p>
                                    </a>
                                  </div>
                                </div>
                              </li>
                              <li class="td td-price">
                                <div class="item-price"> ￥{{fahuo.Good.GoodPrcieper}}.00</div>
                              </li>
                              <li class="td td-number">
                                <div class="item-number"><span>×</span>{{fahuo.Ordernum}}</div>
                              </li>
                              <li class="td td-operation">
                                <div class="item-operation">
                                  <a href="#" @click="ordertuik(fahuo.Orderid)">退款</a>
                                </div>
                              </li>
                            </ul>
                          </div>
                          <div class="order-right">
                            <li class="td td-amount">
                              <div class="item-amount">
                                合计：￥{{fahuo.Ordersum}}
                              </div>
                            </li>
                            <div class="move-right">
                              <li class="td td-status">
                                <div class="item-status">
                                  <p class="Mystatus">买家已付款</p>
                                  <p class="order-info">
                                    <a href="#" @click="dingxiangqi(fahuo.Orderid)">订单详情</a>
                                  </p>
                                </div>
                              </li>
                              <li class="td td-change">
                                <div class="am-btn am-btn-danger anniu" @click="quer(fahuo.Orderid)" style="width: 91px;height: 38px;text-align: center;line-height: 36px;">
                                  提醒发货
                                </div>
                              </li>
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
                <!-- 待收货 -->
                <div class="am-tab-panel am-fade" id="tab4">
                  <div class="order-top">
                    <div class="th th-item">
                      <td class="td-inner" style="position: relative;left: 81px;">商品</td>
                    </div>
                    <div class="th th-price">
                      <td class="td-inner">单价</td>
                    </div>
                    <div class="th th-number">
                      <td class="td-inner">数量</td>
                    </div>
                    <div class="th th-operation">
                      <td class="td-inner" style="position: relative;left: 30px;">商品操作</td>
                    </div>
                    <div class="th th-amount">
                      <td class="td-inner">合计</td>
                    </div>
                    <div class="th th-status">
                      <td class="td-inner">交易状态</td>
                    </div>
                    <div class="th th-change">
                      <td class="td-inner">交易操作</td>
                    </div>
                  </div>

                  <div class="order-main">
                    <div class="order-list" v-for="shouhuo in orderdaishouhuo" :key="shouhuo.Orderid">
                      <div class="order-status3">
                        <div class="order-title" style="background-color: #F5F5F5;">
                          <div class="dd-num">
                            订单编号：<a href="javascript:;">{{shouhuo.Ordername}}</a>
                          </div>
                          <span>成交时间：{{shouhuo.Ordertime | dateFormat }}</span>
                          <!--    <em>店铺：小桔灯</em>-->
                        </div>
                        <div class="order-content">
                          <div class="order-left">
                            <ul class="item-list">
                              <li class="td td-item">
                                <div class="item-pic">
                                  <a href="#" class="J_MakePoint">
                                    <img
                                      :src="'http://81.68.132.153:7070/img/'+shouhuo.Good.GoodImage"
                                      class="itempic J_ItemImg"
                                    />
                                  </a>
                                </div>
                                <div class="item-info">
                                  <div class="item-basic-info">
                                    <a href="#">
                                      <p>
                                       {{shouhuo.Good.GoodfuName}}
                                      </p>
                                      <p class="info-little">
                                         类型:{{shouhuo.Goodtypetwo.Goodtypetwoname}}
                                      </p>
                                    </a>
                                  </div>
                                </div>
                              </li>
                              <li class="td td-price">
                                <div class="item-price">￥{{shouhuo.Good.GoodPrcieper}}.00</div>
                              </li>
                              <li class="td td-number">
                                <div class="item-number"><span>×</span>{{shouhuo.Ordernum}}</div>
                              </li>
                              <li class="td td-operation">
                                <div class="item-operation">
                                  <a href="#" @click="ordertuik(shouhuo.Orderid)">退款/退货</a>
                                </div>
                              </li>
                            </ul>
                          </div>
                          <div class="order-right">
                            <li class="td td-amount">
                              <div class="item-amount">
                                合计：￥{{shouhuo.Ordersum}}.00
                              </div>
                            </li>
                            <div class="move-right">
                              <li class="td td-status">
                                <div class="item-status">
                                  <p class="Mystatus">卖家已发货</p>
                                  <p class="order-info">
                                    <a href="#" @click="dingxiangqi(shouhuo.Orderid)">订单详情</a>
                                  </p>
                                  <p class="order-info">
                                    <a href="#"  @click="faUserdzhu(shouhuo.Orderid)">查看物流</a>
                                  </p>
                                </div>
                              </li>
                              <li class="td td-change" @click="qurshouhuo(shouhuo.Orderid)">
                                <div class="am-btn am-btn-danger anniu" style="width: 91px;height: 38px;text-align: center;line-height: 36px;">
                                  确认收货
                                </div>
                              </li>
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
                   <!-- 待评价 -->
                <div class="am-tab-panel am-fade" id="tab5">
                  <div class="order-top">
                    <div class="th th-item">
                      <td class="td-inner" style="position: relative;left: 81px;">商品</td>
                    </div>
                    <div class="th th-price">
                      <td class="td-inner">单价</td>
                    </div>
                    <div class="th th-number">
                      <td class="td-inner">数量</td>
                    </div>
                    <div class="th th-operation">
                      <td class="td-inner" style="position: relative;left: 30px;">商品操作</td>
                    </div>
                    <div class="th th-amount">
                      <td class="td-inner">合计</td>
                    </div>
                    <div class="th th-status">
                      <td class="td-inner">交易状态</td>
                    </div>
                    <div class="th th-change">
                      <td class="td-inner">交易操作</td>
                    </div>
                  </div>

                  <div class="order-main">
                    <div class="order-list" v-for="shouhuo in orderpingjia" :key="shouhuo.Orderid">
                      <div class="order-status3">
                        <div class="order-title" style="background-color: #F5F5F5;">
                          <div class="dd-num">
                            订单编号：<a href="javascript:;">{{shouhuo.Ordername}}</a>
                          </div>
                          <span>成交时间：{{shouhuo.Ordertime | dateFormat }}</span>
                          <!--    <em>店铺：小桔灯</em>-->
                        </div>
                        <div class="order-content">
                          <div class="order-left">
                            <ul class="item-list">
                              <li class="td td-item">
                                <div class="item-pic">
                                  <a href="#" class="J_MakePoint">
                                    <img
                                      :src="'http://81.68.132.153:7070/img/'+shouhuo.Good.GoodImage"
                                      class="itempic J_ItemImg"
                                    />
                                  </a>
                                </div>
                                <div class="item-info">
                                  <div class="item-basic-info">
                                    <a href="#">
                                      <p>
                                       {{shouhuo.Good.GoodfuName}}
                                      </p>
                                      <p class="info-little">
                                         类型:{{shouhuo.Goodtypetwo.Goodtypetwoname}}
                                      </p>
                                    </a>
                                  </div>
                                </div>
                              </li>
                              <li class="td td-price">
                                <div class="item-price">￥{{shouhuo.Good.GoodPrcieper}}.00</div>
                              </li>
                              <li class="td td-number">
                                <div class="item-number"><span>×</span>{{shouhuo.Ordernum}}</div>
                              </li>
                              <li class="td td-operation">
                                <div class="item-operation">
                                </div>
                              </li>
                            </ul>
                          </div>
                          <div class="order-right">
                            <li class="td td-amount">
                              <div class="item-amount">
                                合计：￥{{shouhuo.Ordersum}}.00
                              </div>
                            </li>
                            <div class="move-right">
                              <li class="td td-status">
                                <div class="item-status">
                                  <p class="Mystatus">卖家已发货</p>
                                   <p class="order-info">
                                    <a href="#" @click="dingxiangqi(shouhuo.Orderid)">订单详情</a>
                                  </p>
                                  <p class="order-info">
                                    <a href="#"  @click="faUserdzhu(shouhuo.Orderid)">查看物流</a>
                                  </p>
                                </div>
                              </li>
                              <li class="td td-change" @click="pingjias(shouhuo.Orderid)">
                                <div class="am-btn am-btn-danger anniu" style="width: 91px;height: 38px;text-align: center;line-height: 36px;">
                                  评价商品
                                </div>
                              </li>
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
        </div>
      </div>
    </div>
    <el-dialog title="订单跟踪" :visible.sync="dingdanVisible" width="50%">
         <div style="height: 300px;">
  <el-steps  direction="vertical" :active="ding" finish-status="success">
    <el-step title="订单已提交,待付款"></el-step>
    <el-step title="订单付款成功"></el-step>
    <el-step title="到达目的地,快递很快进行派送"></el-step>
    <el-step title="订单已签收,期待再次为您服务"></el-step>
  </el-steps>
</div>

      <span slot="footer" class="dialog-footer">
        <el-button @click="dingdanVisible = false">取 消</el-button>
        <el-button type="primary" @click="dingdanVisible = false">确认</el-button>
      </span>
    </el-dialog>
  </div>
</template>

<script>
export default {
  data(){
    return{
      //获取用户的id
userid:"",
//获取待付款的数据
orderfuka:[],
//获取待发货的数据
orderfahuo:[],
//获取待收货的数据
orderdaishouhuo:[],
//获取待评价的数据
orderpingjia:[],
//获取已完成的数据
orderyiwangceng:[],
dingdanVisible:false,
 ding:1,
    }
  },
  methods:{
    //待付款
    getorderfuk(){
      this.$axios.get('/api/Food/ordersstatus',{
        params:{
          name:"待付款",
          id:this.userid
        }
      }).then(s=>{
       this.orderfuka=s.data;
        console.log("待付款")
       console.log(this.orderfuka);
      })
    },
    //待发货
    getorderfahuo(){
      this.$axios.get('/api/Food/ordersstatus',{
        params:{
          name:"待发货",
          id:this.userid
        }
      }).then(d=>{
       this.orderfahuo=d.data;
       console.log("待发货")
        console.log(this.orderfahuo);
      })
    },
    //待收货
    getorderdaishouhuo(){
      this.$axios.get('/api/Food/ordersstatus',{
        params:{
          name:"待收货",
          id:this.userid
        }
      }).then(l=>{
         this.orderdaishouhuo=l.data;
         console.log("待收货")
         console.log(this.orderdaishouhuo);
      })
    },
    //待评价
    getorderpingjia(){
      this.$axios.get('/api/Food/ordersstatus',{
        params:{
          name:"待评价",
          id:this.userid
        }
      }).then(a=>{
         this.orderpingjia=a.data;
         console.log("待评价")
         console.log(this.orderpingjia);
      })
    },
    //已完成
    getorderyiwangceng(){
      this.$axios.get('/api/Food/ordersstatus',{
        params:{
          name:"已完成",
          id:this.userid
        }
      }).then(b=>{
        this.orderyiwangceng=b.data;
        console.log("已完成")
        console.log(this.orderyiwangceng);
      })
    },
    //提醒发货
    quer(sender){
      this.$axios.get('/api/Food/ordersselect?id='+sender).then(d=>{
         if (d.data[0].Ordertixifahuo=="true") {
            this.$message.success('亲!已经帮你提醒发货，请耐心等待!');
         console.log(d.data);
         }
         else{
 this.$axios.get('/api/Food/ordertixifahuos?id='+sender).then(s=>{
          if (s.data=="修改成功") {
            this.$message.success('亲!已经帮你提醒商家发货，请耐心等待!');
          }
          else{
              this.$message.error('失败!')
          }
        })
         }
        })
    },
    //跳转到退款
    ordertuik(id){
       this.$router.push({
                path: "/qianduan/orderrefund",
                query: {
                  userids: id,
                },
    });
  },
  //跳转到订单详情
  dingxiangqi(id){

     this.$router.push({
                path: "/qianduan/orderxiangqi",
                query: {
                  userids: id,
                },
    });
  },
//取消订单
quxiao(id){
  this.$axios.get('/api/Food/orderdelete?id='+id).then(s=>{
    if (s.data=="删除成功") {
      this.$message.success("取消订单成功");
      this.getorderfuk();
    }
    else{
      this.$message.error("取消订单失败");
    }
  });
},
//根据id查询物流
    faUserdzhu(id){
this.dingdanVisible = true;
      this.$axios
        .get("/api/Food/ordersselect?id=" + id)
        .then((d) => {
          if (d.data != "") {
            if (d.data[0].Orderstatus=="待付款") {
              
              this.ding=1;this.dingxix="等待付款中";
            }
            if (d.data[0].Orderstatus=="待发货") {
              this.ding=2;
              this.dingxix="买家已付款，等待商家发货中，请耐心等待！";
            }
            if (d.data[0].Orderstatus=="待收货") {
              this.ding=3;
              this.dingxix="等待确认收货中";
            }
            if (d.data[0].Orderstatus=="已完成") {
              this.ding=4;
              this.dingxix="已签收，期待下次为您服务！";
            }
            if (d.data[0].Orderstatus=="待评价") {
              this.ding=4;
              this.dingxix="已签收，期待下次为您服务！";
            }
            console.log(d.data);
          } else {
            this.$message.error("查询发货信息失败");
          }
        })
        .catch();
    },
    //购买
     gouma(sender) {
       this.$axios.get('/api/Food/goodkoweizname?name='+sender.Good.GoodName).then(s=>{
         if (s.data!="") {
           this.$axios.get('/api/Food/ordersidsd?id='+sender.Good.Goodid).then(l=>{
             if (l.data!="") {
                this.$router.push({
                      path: "/qianduan/pay",
                      query: {
                        shoppid: this.userid,
                        koweis:s.data[0].Goodkoweiname,
                        numss:sender.Ordernum,
                        ordersids:l.data[0].Orderid
                      },
                    });
             }
           });
         
          console.log("sssssssssss");
          console.log(s.data[0].Goodkoweiname);
          console.log(s.data);
         }
       });
         
    },
    //确认收货
    qurshouhuo(id){
    this.$axios.get('/api/Food/ordertixiyiwangchuos?id='+id).then(s=>{
      if (s.data=="修改成功") {
         this.$message.success("确认收货成功");
          this.getorderdaishouhuo();
          this.getorderpingjia();
    this.getorderyiwangceng();
      }
      else{
        this.$message.error("确认收货失败");
      }
    });
    },
    //跳转到评价
    pingjias(id){
   this.$router.push({
                path: "/qianduan/pingjia",
                query: {
                  userids: this.userid,
                  orderid:id
                },
                });
    },
    //删除订单
    shanchuorder(id){
 this.$axios.get('/api/Food/orderdelete?id='+id).then(l=>{
                            if (l.data=="删除成功") {
                               this.$message.success("删除订单成功");
                               this.getorderyiwangceng();
                            }
                            else{
                              this.$message.success("删除订单失败");
                            }
                        });
    }
  },
  created(){
      this.userid = this.$route.query.userids;
      this.getorderfuk();
      this.getorderfahuo();
      this.getorderdaishouhuo();
      this.getorderpingjia();
      this.getorderyiwangceng();
}
}
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
  /* border-bottom: 2px solid #f03726; */
  border-top:none;
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
<style scoped>
.user-order .am-margin {
  margin: 0;
}
.am-nav-tabs > li > a {
  padding: 0px 2px;
  margin: 0px 0px;
  text-align: center;
}
.order-left {
  border: 1px solid #e4eaee;
  padding: 5px;
}
.am-tabs-bd .am-tab-panel {
  padding: 0px 0px 15px;
}
img {
  width: 100%;
}
.inquire {
  display: none;
}
/*布局*/
.order-top {
  display: none;
  width: 100%;
  overflow: hidden;
  padding: 10px 0px;
  border: 1px solid #eee;
}
.th,
.td {
  float: left;
  text-align: center;
}
.item-list {
  position: relative;
  overflow: hidden;
}
.td-item {
  width: 80%;
  overflow: hidden;
}
.td-price {
  position: absolute;
  top: 0px;
  right: 5px;
  width: 20%;
  text-align: right;
}
.td-number {
  position: absolute;
  top: 20px;
  right: 5px;
  width: 10%;
  text-align: right;
}
.td-operation {
  position: absolute;
  top: 40px;
  right: 5px;
  width: 30%;
  text-align: right;
}

/*编号*/
.dd-num {
  width: 50%;
  float: left;
  max-width: 250px;
}
.order-title {
  overflow: hidden;
  padding: 10px 0px;
}
.order-title span {
  display: none;
}
/*商品信息*/
.item-pic {
  width: 80px;
  height: 80px;
  border: 1px solid #eee;
  float: left;
  overflow: hidden;
  margin-top: 20px;
  margin-left: 3px;
}
.item-info {
  margin: 0px 0px 0px 91px;
  padding-right: 25px;
}
.item-basic-info {
  padding-top: 20px;
  text-align: left;
}

.td-price,
.td-number,
.td-operation {
  margin-top: 20px;
}
.user-order .am-btn {
  font-size: 14px;
  color: #fff;
}
.info-little {
  color: #9c9c9c;
}

/*右侧操作定位*/
.order-content {
  position: relative;
}
.order-left ul {
  width: 100%;
  overflow: hidden;
}
.order-right {
  width: 100%;
  overflow: hidden;
}
.order-right .td-amount,
.td-changeorder {
  width: 100%;
  text-align: right;
  font-size: 14px;
  font-weight: 600;
  padding: 10px 5px;
}
.order-right .td-amount p {
  display: inline;
  font-weight: 100;
}
.td-status p.Mystatus {
  position: absolute;
  top: -25px;
  right: 0px;
  color: #dd514c;
}
.td-status p.order-info {
  height: 32px;
  line-height: 32px;
  border: 1px solid #e4eaee;
  padding: 0px 5px;
}
/*退换货管理*/
.td-changeorder li {
  float: right;
}

.td.td-change.td-changebutton {
  width: 100%;
  text-align: right;
  margin-top: 5px;
}
.move-right {
  float: right;
}

/*修改布局*/
.td-status p.order-info {
  float: left;
  margin-right: 5px;
}

/*订单详情*/
/*进度条*/
.m-progress {
  margin: 0 auto 10px;
  height: 60px;
  max-width: 700px;
  margin-top: 40px;
}
.m-progress-list {
  height: 66px;
  font-size: 0;
  text-align: justify;
}
/*步骤背景*/
.m-progress-list .step {
  display: inline-block;
  width: 60px;
  text-align: center;
  color: #999;
  letter-spacing: -5px;
}
.m-progress-list .stage-name {
  padding-top: 10px;
  font-size: 12px;
  line-height: 14px;
  letter-spacing: normal;
  word-spacing: normal;
}
.u-progress-stage-bg {
  position: relative;
  display: inline-block;
  background-image: url(../../assets/images/sprite.png);
  background-position: -45px -135px;
  width: 29px;
  height: 29px;
}
/*变换的背景*/
.u-stage-icon-inner .bg {
  position: absolute;
  left: 0px;
  top: 0px;
}
.step-1 .u-stage-icon-inner .bg {
  background-image: url(../../assets/images/sprite.png);
  background-position: -79px -135px;
  width: 19px;
  height: 19px;
}
.step-2 .u-stage-icon-inner .bg {
  background-image: url(../../assets/images/sprite.png);
  background-position: -103px -135px;
  width: 19px;
  height: 19px;
}

.u-stage-icon-inner {
  position: relative;
  z-index: 20;
  display: inline-block;
  width: 19px;
  height: 19px;
  line-height: 19px;
  vertical-align: top;
  margin-top: 5px;
  margin-left: -24px;
  color: #b5b5b5;
  font-size: 12px;
  letter-spacing: normal;
  word-spacing: normal;
}
.u-progress-placeholder {
  display: inline-block;
  width: 100%;
  height: 0;
  font-size: 0;
  line-height: 0;
  overflow: hidden;
}

.u-progress-bar {
  margin: -56px 40px 0;
  background-color: #dcdcdc;
  height: 5px;
  font-size: 0;
  padding: 2px 0;
}
.u-progress-bar-inner {
  position: relative;
  z-index: 10;
  height: 5px;
  width: 0;
  transition: width 1s 0.5s linear;
  background-color: #23c279;
}

/*物流信息*/
.order-logistics {
  position: relative;
  font-size: 14px;
  padding: 10px;
  border-top: 1px solid #e4eaee;
}
.latest-logistics {
  margin-left: 30px;
  margin-right: 15px;
}
.order-logistics .icon-log {
  position: absolute;
  top: 50%;
  margin-top: -9px;
  width: 22px;
  left: 10px;
}
.order-logistics span.icon {
  position: absolute;
  right: 10px;
  top: 50%;
  margin-top: -10px;
}
/*收货地址*/
.order-addresslist {
  font-size: 14px;
  width: 100%;
  padding: 10px;
  border-top: 1px solid #e4eaee;
  position: relative;
}
.icon-add {
  background: url(../../assets/images/addicon.png) 4px 3px no-repeat;
  width: 20px;
  height: 20px;
  position: absolute;
  top: 50%;
  margin-top: -10px;
}
.new-mu_l2a,
.new-tit.new-p-re {
  padding: 2px 0px 2px 30px;
  display: block;
}
.user-orderinfo .order-title,
.user-orderinfo .td-status p.Mystatus {
  display: none;
}

@media only screen and (min-width: 640px) {
  .am-tabs-bd .am-tab-panel {
    padding: 10px 10px 15px;
  }
  .order-top {
    display: block;
  }
  .dd-num {
    width: 30%;
  }
  .order-title span {
    display: inline;
  }
  .th {
    line-height: 16px;
  }
  /*订单信息*/
  .order-infomain .order-status3 .item-status {
    margin-top: -8px;
  }
  .order-infomain .order-status4 .item-status {
    margin-top: 0px;
  }

  /*布局*/
  .td-price,
  .td-number {
    margin-top: 23px;
  }
  .th-item,
  .td-item {
    width: 67%;
    overflow: hidden;
  }
  .th-price,
  .td-price {
    position: static;
    width: 10%;
    text-align: center;
  }
  .th-number,
  .td-number {
    position: static;
    width: 8%;
    text-align: center;
  }
  .th-operation,
  .td-operation {
    position: static;
    width: 15%;
    text-align: center;
  }
  .th-amount,
  .th-status,
  .th-change {
    display: none;
  }
  .td-amount {
    font-size: 16px;
  }
  .td-status p.Mystatus {
    text-align: center;
    width: 15%;
    top: -30px;
  }

  /*退换货管理*/
  ul.td-changeorder {
    width: 20%;
  }
  .td-changeorder li {
    float: left;
    width: 50%;
    margin-top: 10px;
    font-size: 12px;
    font-weight: 100;
  }
  .td-changeorder li span {
    display: none;
  }

  .change.move-right {
    position: absolute;
    top: 0;
    right: 0;
    width: 10%;
    text-align: center;
  }
  .th-moneystatus {
    display: block;
  }
  .td-moneystatus p.Mystatus {
    position: static;
    width: 100%;
    margin-top: 24px;
  }

  .user-orderinfo .order-title,
  .user-orderinfo .td-status p.Mystatus {
    display: block;
  }
}

@media only screen and (min-width: 1025px) {
  /*布局*/

  .th-item,
  .td-item {
    width: 40%;
    overflow: hidden;
  }
  .th-price,
  .td-price {
    width: 10%;
  }
  .th-number,
  .td-number {
    width: 5%;
  }
  .th-operation,
  .td-operation {
    width: 15%;
  }
  .th-amount,
  .th-status,
  .th-change {
    display: block;
    width: 10%;
  }

  /*右侧操作定位*/
  .order-content {
    position: relative;
    overflow: hidden;
  }
  .order-left ul {
    width: 100%;
    overflow: hidden;
  }
  .order-right {
    width: 30%;
    position: absolute;
    top: 50%;
    margin-top: -16px;
    right: 0;
    overflow: visible;
  }
  .order-right .td {
    width: 33.33%;
    float: left;
    text-align: center;
    position: static;
    padding: 0px 0px;
  }
  .order-right .td-amount {
    font-size: 12px;
  }
  .order-right .td-amount p {
    display: block;
  }
  .order-right .td-status p.Mystatus {
    position: static;
    width: 100%;
    color: #000;
  }
  .order-right .td-status p.order-info {
    height: 16px;
    line-height: 16px;
    border: none;
    padding: 0px 0px;
  }
  .move-right {
    float: none;
  }

  /*退换货管理*/
  ul.td-changeorder {
    width: 20%;
  }
  .td-moneystatus {
    width: 100%;
  }
  .change.move-right {
    position: absolute;
    top: 0;
    right: 30%;
  }
  /*退换货管理按钮*/
  .td.td-change.td-changebutton {
    position: absolute;
    top: 0;
    right: 0;
    width: 30%;
    text-align: center;
    margin-top: 20px;
  }

  .th-changebuttom {
    width: 30%;
    text-align: center;
  }

  /*修改布局*/
  .td-status p.order-info {
    float: none;
    margin-right: 0px;
  }
  .order-status3 .item-status {
    margin-top: -16px;
  }
  .order-status4 .item-status,
  .order-status5 .item-status {
    margin-top: -8px;
  }
  .order-status0 .item-status {
    margin-top: 8px;
  }

  /*修改订单详情*/
  .order-infoaside {
    margin: 20px 0px;
    overflow: hidden;
    max-width: 900px;
  }
  .order-logistics {
    float: right;
    width: 65%;
    border: none;
    height: 170px;
    position: relative;
  }
  .order-addresslist {
    float: left;
    border: none;
    width: 280px;
    height: 170px;
    padding: 0px 10px;
  }
  .order-address {
    width: 252px;
    background: url(../../assets/images/peraddbg.png) no-repeat scroll 0% 0%;
    height: 151px;
    margin: 0px auto;
    padding: 10px;
  }
  .icon-add,
  .order-logistics .icon-log {
    top: 0px;
    margin-top: 12px;
  }
  .inquire {
    display: block;
    position: absolute;
    bottom: 50px;
  }
  .order-logistics span.icon {
    display: none;
  }
}
</style>