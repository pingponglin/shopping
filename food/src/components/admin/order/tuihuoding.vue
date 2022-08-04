<template>
  <div>
<el-breadcrumb separator-class="el-icon-arrow-right">
      <el-breadcrumb-item :to="{ path: '/shou' }">首页</el-breadcrumb-item>
      <el-breadcrumb-item>订单</el-breadcrumb-item>
      <el-breadcrumb-item>退货信息</el-breadcrumb-item>
    </el-breadcrumb>
     <el-card>
         <div class="di"><br>
             <span style="margin-left:40px; margin-top: 20px;">退货商品</span>
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
        <el-table-column prop="Order.Ordernum" label="数量" width="160">
        </el-table-column>
        <el-table-column prop="Order.Ordersum" label="小计" width="208">
            <template slot-scope="tableData">
                <span>￥{{tableData.row.Order.Ordersum}}</span>
            </template>
        </el-table-column>
      </el-table>
         </div>
         <div class="di1" v-for="item in tableData" :key="item.Orderid">
             <span style="margin-left:40px; position: relative;
  top: 10px;">退货信息</span>
<el-row style="margin-left:32px;margin-top: 30px;">
  <el-col :span="6"><div class="rows">订单编号</div></el-col>
  <el-col :span="18"><div class="co">{{item.Order.Ordername}}</div></el-col>
</el-row>
<el-row style="margin-left:32px;">
   <el-col :span="6"><div class="rows">申请状态</div></el-col>
  <el-col :span="18"><div class="co">{{item.Ordertuihuostatus}}</div></el-col>
</el-row>
<el-row style="margin-left:32px;">
  <el-col :span="6"><div class="rows">处理时间</div></el-col>
  <el-col :span="18"><div class="co">{{item.Ordertuihuodate}}</div></el-col>
</el-row>
<el-row style="margin-left:32px;">
  <el-col :span="6"><div class="rows">用户</div></el-col>
  <el-col :span="18"><div class="co">{{item.Order.Address.Userxix.Userxixname}}</div></el-col>
</el-row>
<el-row style="margin-left:32px;">
  <el-col :span="6"><div class="rows">联系电话</div></el-col>
  <el-col :span="18"><div class="co">{{item.Order.Address.Userxix.Userxixphone}}</div></el-col>
</el-row>
<el-row style="margin-left:32px;">
  <el-col :span="6"><div class="rows">退款类型</div></el-col>
  <el-col :span="18"><div class="co">{{item.Ordertuihuotype}}</div></el-col>
</el-row>
<el-row style="margin-left:32px;">
  <el-col :span="6"><div class="rows">退款原因</div></el-col>
  <el-col :span="18"><div class="co">{{item.Ordertuihuoyuangyi}}</div></el-col>
</el-row>
<el-row style="margin-left:32px;">
  <el-col :span="6"><div class="rows">退款说明</div></el-col>
  <el-col :span="18"><div class="co">{{item.Ordertuihuoshuomin}}</div></el-col>
</el-row>
<el-row style="margin-left:32px;">
  <el-col :span="6"><div class="rowss">退款图片</div></el-col>
  <el-col :span="18"><div class="co" style="display: flex;">
    <div v-for="or in url" :key="or.index">
  <img :src="'http://81.68.132.153:7070/img/'+or" style="width:100px;height:100px;"></div>
  </div></el-col>
</el-row>
<el-row style="margin-left:32px;margin-bottom: 0px;">
      <el-col :span="6"><div class="rows">确认退款金额</div></el-col>
  <el-col :span="18"><div style="border: 1px solid #DCDFE6;width:400px;padding:10px;border-bottom: none;
    border-left: none;">￥{{item.Ordertuihuomoneys}}</div></el-col>
</el-row>
<el-row style="margin-left:32px;margin-bottom: 30px;position: relative;
  bottom: 10px;">
    <el-col :span="6"><div style="background-color: #F2F6FC;padding:10px;border:1px solid #DCDFE6;">详情地址</div></el-col>
  <el-col :span="18"><div style="  border: 1px solid #DCDFE6;width:400px;padding:10px;border-left: none;">{{item.Order.Address.Addresssuozaidiqu}}{{item.Order.Address.Addressxiangxidiqu}}</div></el-col>
</el-row>
 <div style="margin-bottom:20px;text-align: center">
        <el-button type="primary" size="small" @click="tuihuo" v-show="ds(item.Ordertuihuostatus)">确认退货</el-button>
        <el-button type="danger" size="small" @click="jujuetuihuo" v-show="td(item.Ordertuihuostatus)">拒绝退货</el-button>
        <el-button type="warning" size="small" @click="tuihuos">取消</el-button>
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
  Order:{}
},
url:[]
    }
},
methods:{
    //根据id查询所有退货信息
    getlist(){
        this.$axios.get('/api/Food/ordertuihuoid?id='+this.d).then(s=>{
            if (s.data!="") {
                this.tableData=s.data;
                this.datafrom=s.data;
                this.url=s.data[0].OrdertuihuoImage;
                let imgss = s.data[0].OrdertuihuoImage.split("/");
               this.url=imgss;
        // for (let i = 0; i < imgss.length; i++) {
        //   console.log(1);
        //   this.url=imgss[i];
        // }
        console.log("sadsadassd");
        console.log(this.url);
                console.log("sss")
                console.log(this.tableData)
                console.log(this.datafrom)
            }
            else{
                this.$message.error("查询发货信息失败");
            }
        })
    },
    //确认退货
    tuihuo(){
        this.$axios.get('/api/Food/ordertuihuoupdate?id='+this.d).then(s=>{
            if (s.data=="退货成功") {
                this.$router.push('/order/ordertuihuo');
                this.$message.success('退货成功!');
            }
            else{
                 this.$message.error("退货失败");
            }
        })
    },
    //拒绝退货
    jujuetuihuo(){
this.$axios.get('/api/Food/ordertuihuojujupdate?id='+this.d).then(s=>{
            if (s.data=="拒绝成功") {
                this.$router.push('/order/ordertuihuo');
                this.$message.success('拒绝成功!');
            }
            else{
                 this.$message.error("拒绝失败");
            }
        })
    },
    td(id){
       if (id=="待处理"||id=="退货中") {
         return true;
       }
       else{
         return false;
       }
    },
    //取消退货
    tuihuos(){
this.$router.push('/order/ordertuihuo');
    },
    ds(sender){
        if (sender=="已完成"||sender=="已拒绝") {
            return false;
        }
        return true;
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

<style scoped>
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
.rowss {
  padding: 10px 0px;
    overflow: hidden;
    background-color: #F2F6FC;
    padding: 10px;
    height: 122px;
    border: 1px solid #DCDFE6;
    border-bottom: none;
}
</style>