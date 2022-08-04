<template>
  <div class="tinymce-editor">
    <editor
      v-model="myValue"
      :init="init"
      :disabled="disabled"
      @onClick="onClick"
      class="s"
    ></editor>
  </div>
</template>
<script>
import axios from "axios";
import tinymce from "./../../public/tinymce/tinymce";
import Editor from "@tinymce/tinymce-vue";
import "./../../public/tinymce/themes/silver";
import "./../../public/tinymce/plugins/paste";
import "./../../public/tinymce/plugins/image";
import "./../../public/tinymce/plugins/link";
import "./../../public/tinymce/plugins/code";
import "./../../public/tinymce/plugins/table";
import "./../../public/tinymce/plugins/lists";
import './../../public/tinymce/skins/ui/oxide/skin.css';
import './../../public/tinymce/skins/ui/oxide/content.min.css';
import './../../public/tinymce/langs/zh_CN';
import './../../public/tinymce/plugins/preview';
import './../../public/tinymce/plugins/emoticons';
import './../../public/tinymce/plugins/emoticons/js/emojis';
import './../../public/tinymce/plugins/hr';
import './../../public/tinymce/plugins/print';
import './../../public/tinymce/plugins/anchor';
import './../../public/tinymce/plugins/imagetools';
import './../../public/tinymce/icons/default/icons';
import "./../../public/tinymce/plugins/wordcount/plugin";

export default {
  components: {
    Editor
  },
  props: {
    value: {
      type: String,
      default: ""
    },
    disabled: {
      type: Boolean,
      default: false
    },
    plugins: {
      type: [String, Array],
      default:
        "link lists image code table wordcounts"
    },
    toolbar: {
      type: [String, Array],
      default:
        "bold italic underline strikethrough | fontsizeselect fontselect | forecolor backcolor | alignleft aligncenter alignright alignjustify | bullist numlist | outdent indent blockquote | undo redo | link unlink code | removeformat"
    }
  },
  data() {
    return {
      init: {
        language_url: "./../../public/plugins/tinymce/langs/zh_CN.js", //如果语言包不存在，指定一个语言包路径
        language: "zh_CN", //语言
        skin_url: "./../../public/plugins/tinymce/skins/ui/oxide", //如果主题不存在，指定一个主题路径
        content_css: "./../../public/plugins/tinymce/mycontent.css",
        height: "300px",
        width: "550px",
        plugins: this.plugins, //插件
        toolbar: this.toolbar, //工具栏
        branding: false, //技术支持(Powered by Tiny || 由Tiny驱动)
        menubar: true, //菜单栏
        theme: "silver", //主题
        zIndex: 1101,
    //     width: 800,
    //   height: 300,
      },
      myValue: this.value
    };
  },
  mounted() {
    tinymce.init({});
  },
  methods: {
    calcWidth() {
      return document.body.clientWidth / 2 + "px";
    },
  },
  watch: {
    value(newValue) {
      this.myValue = newValue;
    },
    myValue(newValue) {
      this.$emit("input", newValue);
    }
  },
  created(){
  }
};
</script>
<style  scoped>
.tox .tox-tinymce{
  height: 300px;
  width: 100px;
}
</style>