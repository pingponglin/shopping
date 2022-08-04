<template>
  <div>
<el-breadcrumb separator-class="el-icon-arrow-right">
      <el-breadcrumb-item :to="{ path: '/shou' }">首页</el-breadcrumb-item>
      <el-breadcrumb-item>订单</el-breadcrumb-item>
      <el-breadcrumb-item>订单信息</el-breadcrumb-item>
    </el-breadcrumb>
     <el-card>
         <div class="di"><br>
             <span style="margin-left:40px; margin-top: 20px;">订单商品</span>
<el-table :data="tableData" border stripe style="width:90%;margin-left:40px;margin-bottom: 30px;">
        <el-table-column prop="Good.GoodImage" label="商品图片" width="170">
          <template v-slot="tableData">
            <img
              :src="'http://81.68.132.153:7070/img/'+tableData.row.Good.GoodImage"
              width="100"
              height="100"
            />
          </template>
        </el-table-column>
        <el-table-column prop="Good.GoodName" label="商品名称" width="190">
        </el-table-column>
        <el-table-column prop="Good.GoodPrice" label="商品价格" width="160">
        </el-table-column>
        <el-table-column prop="Ordernum" label="数量" width="160">
        </el-table-column>
        <el-table-column prop="Ordersum" label="小计" width="208">
            <template slot-scope="tableData">
                <span>￥{{tableData.row.Ordersum}}</span>
            </template>
        </el-table-column>
      </el-table>
         </div>
         <div class="di1" v-for="item in tableData" :key="item.Orderid">
             <span style="margin-left:40px; position: relative;
  top: 10px;">订单信息</span>
<el-row style="margin-left:32px;margin-top: 30px;">
  <el-col :span="6"><div class="rows">订单编号</div></el-col>
  <el-col :span="18"><div class="co">{{item.Ordername}}</div></el-col>
</el-row>
<el-row style="margin-left:32px;">
   <el-col :span="6"><div class="rows">订单状态</div></el-col>
  <el-col :span="18"><div class="co">{{item.Orderstatus}}</div></el-col>
</el-row>
<el-row style="margin-left:32px;">
  <el-col :span="6"><div class="rows">订单时间</div></el-col>
  <el-col :span="18"><div class="co">{{item.Ordertime}}</div></el-col>
</el-row>
<el-row style="margin-left:32px;">
  <el-col :span="6"><div class="rows">收货人</div></el-col>
  <el-col :span="18"><div class="co">{{item.Address.Addressname}}</div></el-col>
</el-row>
<el-row style="margin-left:32px;">
  <el-col :span="6"><div class="rows">联系电话</div></el-col>
  <el-col :span="18"><div class="co">{{item.Address.Addressphone}}</div></el-col>
</el-row>
<el-row style="margin-left:32px;">
  <el-col :span="6"><div class="rows">收货地址</div></el-col>
  <el-col :span="18"><div class="co">{{item.Address.Addresssuozaidiqu}}</div></el-col>
</el-row>
<el-row style="margin-left:32px;">
  <el-col :span="6"><div class="rows">物流方式</div></el-col>
  <el-col :span="18"><div class="co">{{item.Orderwuliu}}</div></el-col>
</el-row>
<el-row style="margin-left:32px;margin-bottom: 0px;">
      <el-col :span="6"><div class="rows">订单总金额</div></el-col>
  <el-col :span="18"><div style="border: 1px solid #DCDFE6;width:400px;padding:10px;border-bottom: none;
    border-left: none;">￥{{item.Ordersum}}</div></el-col>
</el-row>
 <div style="margin-bottom:20px;text-align: center">
        <el-button type="primary" size="small" @click="qr">确认</el-button>
        <el-button type="danger" size="small" @click="qx">取消</el-button>
      </div>
         </div>
     </el-card>
  </div>
</template>

<script>
export default {
data(){
    return{
d:"",
//获取退货信息的值
tableData:[],
datafrom:{
  
}
    }
},
methods:{
    //根据id查询所有退货信息
    getlist(){
        this.$axios.get('/api/Food/ordersselect?id='+this.d).then(s=>{
            if (s.data!="") {
                this.tableData=s.data;
                this.datafrom=s.data;
                console.log(s.data)
                console.log(this.datafrom)
            }
            else{
                this.$message.error("查询发货信息失败");
            }
        })
    },
    //取消退货
    qx(){
this.$router.push('/order/order');
    },
    qr(){
        this.$router.push('/order/order');
    }
}
,
created(){
   this.d=this.$route.query.ids;
   console.log(this.$route.query.ids);
   this.getlist();
}
}
</script>

<style>
.el-breadcrumb {
  margin-bottom: 15px;
  font-size: 12px;
  
}
.el-card {
  box-shadow: 0 1px 1px rgba(0, 0, 0, 0.15) !important;
  height: 100%;
}
.di{
     border: 1px solid #DCDFE6;
     width: 80%;
     height: 100%;
     border-radius: 10px 10px;
     margin-bottom: 10px;
     
}
.di1{
     border: 1px solid #DCDFE6;
     width: 80%;
     height: 100%;
     border-radius: 10px 10px;
     
}

.co{
    border: 1px solid #DCDFE6;width:400px;padding:10px;border-bottom: none;
    border-left: none;
}
.rows {
  padding: 10px 0px;
    overflow: hidden;
    background-color: #F2F6FC;
    padding: 10px;
    border: 1px solid #DCDFE6;
    border-bottom: none;
}
</style>