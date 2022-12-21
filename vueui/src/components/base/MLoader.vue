<template>
  <div class="m-loader-wrapper">
    <div class="m-loader">
      <div class="loading--circle"></div>
      <div class="loading--circle"></div>
      <div class="loading--circle"></div>
      <div class="loading--circle"></div>
      <div class="loading--text">{{loaderText.Loading}}</div>
    </div>
  </div>
</template>

<script>
import Resources from "./../../utils/resources/common"

export default {
  name: "MLoader",

  data() {
    return {
      loaderText: Resources.Loader
    }
  },
};
</script>

<style scoped>
    @import url(../../styles/component/loader.css);
</style>