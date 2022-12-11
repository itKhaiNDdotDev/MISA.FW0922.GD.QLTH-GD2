<template>
  <div class="m-loader-wrapper">
    <div class="m-loader">
      <div class="loading--circle"></div>
      <div class="loading--circle"></div>
      <div class="loading--circle"></div>
      <div class="loading--circle"></div>
      <div class="loading--text">Đang tải</div>
    </div>
  </div>
</template>

<script>
export default {
  name: "MLoader",
};
</script>

<style scoped>
    @import url(../../styles/component/loader.css);
</style>