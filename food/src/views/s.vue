<template>
  <div>
         <el-badge :value="12" class="item">
  <el-button size="small">评论</el-button>
</el-badge>
    <div class="choose" ref="choose">
      <div
        class="content"
        ref="content"
        @mousemove="handleMove"
        @mouseout="handleOut"
      >
        <img src="../assets/images/01.jpg" />
        <div class="shadow" ref="shadow"></div>
      </div>
      <ul id="listshow">
        <li class="selected">
          <img src="../assets/images/01.jpg" alt="" />
        </li>
      </ul>
    </div>
    <div class="larger" ref="larger">
      <img src="../assets/images/01.jpg" ref="big" />
    </div>
    <div
      class="imgBox"
      ref="imgBox"
      @mouseenter="stopSetInter"
      @mouseleave="startSetInter"
    >
      <img :src="imgList[now].imgSrc" />
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
          :key="index"
          @click="handlePre(index)"
          class="box"
          :class="{ current: now == index }"
        ></li>
      </div>
    </div>
  </div>
</template>
<style scoped>
.imgBox {
  width: 800px;
  height: 400px;
  margin: 20px auto;
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
<style scoped>
.choose {
  width: 400px;
  height: 600px;
  float: left;
  margin: 10px 0 0 10px;
}

.content {
  width: 400px;
  height: 400px;
  position: relative;
}

.content img {
  width: 400px;
  height: 400px;
}
#listshow {
  width: 400px;
  height: 100px;
  margin-top: 20px;
}

#listshow li {
  width: 98px;
  height: 100px;
  float: left;
  border: 1px solid #666;
}

#listshow li img {
  width: 98px;
  height: 100px;
}

#listshow .selected {
  border-color: brown;
}

.larger {
  width: 400px;
  height: 400px;
  position: absolute;
  top: 70px;
  left: 460px;
  float: left;
  overflow: hidden;
  display: none;
}

.larger img {
  width: 800px;
  height: 800px;
  position: absolute;
  left: 0;
  top: 0;
}

.shadow {
  width: 200px;
  height: 200px;
  background-color: rgba(145, 200, 200, 0.4);
  position: absolute;
  left: 0;
  top: 0;
  z-index: 10;
  display: none;
}
</style>


<script>
export default {
  data() {
    return {
      imgList: [
        {
          imgSrc: "https://images5.alphacoders.com/605/thumb-1920-605588.jpg",
          id: 1,
        },
        {
          imgSrc: "https://images4.alphacoders.com/606/thumb-1920-606285.jpg",
          id: 2,
        },
        {
          imgSrc: "https://images8.alphacoders.com/606/thumb-1920-606281.jpg",
          id: 3,
        },
      ],
      now: 0, // 图片的索引
      Interval: "", // 定时器
    };
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
  methods: {
    // 获取元素到文档区域的坐标
    getPosition: function (element) {
      var dc = document,
        rec = element.getBoundingClientRect(),
        x = rec.left, // 获取元素相对浏览器视窗window的左、上坐标
        y = rec.top;
      // 与html或body元素的滚动距离相加就是元素相对于文档区域document的坐标位置
      x += dc.documentElement.scrollLeft || dc.body.scrollLeft;
      y += dc.documentElement.scrollTop || dc.body.scrollTop;
      return {
        left: x,
        top: y,
      };
    },
    handleMove(evt) {
      var larger = this.$refs.larger;
      var shadow = this.$refs.shadow;
      var big = this.$refs.big;
      var pos = this.getPosition(this.$refs.choose);
      var shadowRect = shadow.getBoundingClientRect();
      var bigRect = big.getBoundingClientRect();
      var contentRect = this.$refs.content.getBoundingClientRect();
      var maxX = contentRect.width - shadowRect.width;
      var maxY = contentRect.height - shadowRect.height;

      var X = evt.pageX - pos.left - shadowRect.width / 2;
      var Y = evt.pageY - pos.top - shadowRect.height / 2;

      if (X <= 0) {
        X = 0;
      }
      if (X >= maxX) {
        X = maxX;
      }
      if (Y <= 0) {
        Y = 0;
      }
      if (Y >= maxY) {
        Y = maxY;
      }
      // 防止遮罩层粘滞，跟随鼠标一起滑出大图位置
      var bigX = (X * bigRect.width) / contentRect.width;
      var bigY = (Y * bigRect.height) / contentRect.height;
      //  bigX / bigW = X / contentW,主图和遮罩层之间存在两倍关系，放大图和原图之间也有两倍关系
      shadow.style.left = X + "px";
      shadow.style.top = Y + "px";

      // console.log(X, Y, bigX, bigY);

      big.style.left = -bigX + "px";
      big.style.top = -bigY + "px";

      larger.style.display = "block";
      shadow.style.display = "block";
    },
    handleOut(evt) {
      var larger = this.$refs.larger;
      var shadow = this.$refs.shadow;
      larger.style.display = "none";
      shadow.style.top = "-1000px";
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
        }, 1000)
    },
    handlePre(preIndex) {
        // console.log(this.now)
        this.now = preIndex
    },
//     getsession(){
//       this.$axios.get('/api/Food/GetVerificationCode').then(s=>{
//         console.log("ss");
//         console.log(s.data.data)

// window.localStorage.setItem('cookies',s.data.data);
// console.log(s.data.data)
//          this.$session.set("s",s.data.data);
//       })
     
//     },
//     getss(){
//       console.log(this.$session.get("s"));
//       console.log("ssss")
//       console.log(window.localStorage.getItem('cookies'))
//       //   this.$axios.get('/api/Food/GetVerificationCode1').then(d=>{
//       //   console.log("ss1");
//       //   console.log(d.data)
//       // })
//     }
    
  },
  created(){
    // this.getsession();
    
    // // this.getss();
  }
};
</script>