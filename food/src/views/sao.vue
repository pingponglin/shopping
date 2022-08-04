<template>
  <div style="width: 1000px">
    <!-- <vue-qr
      :text="downloadData.url"
      style="width: 300px; margin-left: 300px"
      :margin="0"
      colorDark="#ccc"
      colorLight="black"
      :logoScale="0.3"
      :size="200"
    ></vue-qr> -->
    
<vue-qr  :dotScale = '1' :text="appSrc" style="width: 300px; margin-left: 900px"></vue-qr>
    <div id="qrcode" v-loading="loading" 
                                element-loading-text="拼命加载中"
                                element-loading-spinner="el-icon-loading"
                                element-loading-background="rgba(0, 0, 0, 0.8)" style="width: 300px; margin-left: 300px"></div> //必须是id 和实例化的第一参数对应

  </div>
</template>
 
<script>
import vueQr from "vue-qr";
import QRCode from "qrcodejs2";
import $ from 'jquery'
 $(function() {  
        var ua = navigator.userAgent.toLowerCase();  
        if (ua.match(/MicroMessenger/i) == "micromessenger") {  
  console.log("true");
            return true;  
        } else {  
    console.log("false");
            return false;  
        }  
    });
export default {
  components: {
    vueQr,
  },
  data() {
    return {
      downloadData: {
        url: "https://blog.csdn.net/Chengbin_Huang/article/details/102546922?ops_request_misc=&request_id=&biz_id=102&utm_term=vue%E4%BD%BF%E7%94%A8%E4%BA%8C%E7%BB%B4%E7%A0%81%E6%8F%92%E4%BB%B6&utm_medium=distribute.pc_search_result.none-task-blog-2~all~sobaiduweb~default-4-.first_rank_v2_pc_rank_v29_1&spm=1018.2226.3001.4187",
        icon: require("../assets/images/er.jpg"),
      },
      nameurl:"付款成功",     
      timer: '',    // 定时器
      idd:3,
      loading:false,
      imgs:require("../assets/images/er.jpg"),
      appSrc:""
    };
  },
  mounted() {
    this.qrcode(); //调用二维码生成的方法
    // document.getElementById("qrcode").innerHTML = "扫码成功";
  },
  created(){
    var src1 = window.location.href
    var src2 = this.$route.path
    var src3 = src1.replace(src2,'/download')
    this.appSrc = src3
    console.log(this.appSrc)
    console.log(this.$route.path)
  },
  methods: {
    qrcode() {
      // 和div的id相同 必须是id  class类名会报错
      // 第二参数是他的配置项
      let qrCode = new QRCode("qrcode", {
        width: 150,
        height: 150,
        render : "canvas",
        text: this.nameurl,
        colorDark: "#000",
        colorLight: "#fff",
        src:'../assets/images/gift_stamp_2.png'
      });
      console.log(qrCode);
       console.log(qrCode._htOption.text);
       this.loading=false;
this.timer = setInterval(() => {    // 通过定时器每间隔一会去请求查询微信支付状态（具体参数根据项目需要而定）
// this.loading=true;
                    // this.handleQueryWxPayStatus(this.idd);
                    
                }, 3000);
    },
    handleQueryWxPayStatus(sender){
     this.loading=true;
      this.$axios.get('/api/Food/ordertuihuoupdatestaus?id='+sender).then(s=>{
        if (s.data=="付款成功") {
        
          // 清除定时器
          console.log('清除定时器')
          clearInterval(this.timer)
        
          // 三秒后跳转到课程详情页面
          setTimeout(() => {  this.loading=false;  this.$message.success("付款成功")
            this.$router.push('/qianduan/security')
          }, 4000)
        }
      })
    },
    ss(){
}
  },
};
</script>