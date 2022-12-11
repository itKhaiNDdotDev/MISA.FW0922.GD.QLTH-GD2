<template lang="">
  <div class="container">
    <the-sidebar></the-sidebar>
    <the-header></the-header>
    <the-content></the-content>
  </div>
</template>

<script>
import TheSidebar from "./components/layout/TheSidebar.vue";
import TheHeader from "./components/layout/TheHeader.vue";
import TheContent from "./components/layout/TheContent.vue";

export default {
  name: 'App',
  components: {
    TheSidebar,
    TheHeader,
    TheContent
  }
};
</script>

<style>
@import url(styles/main.css);
</style>
