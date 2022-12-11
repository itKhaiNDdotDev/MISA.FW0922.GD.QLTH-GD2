<template>
  <div class="m-radio">
    <input class="radio--real" :name="name" type="radio" />
    <div class="radio--pseudo"></div>
  </div>
</template>

<script>
export default {
  name: "MRadio",
  props: ["name"]
};
</script>

<style scoped>
    @import url(../../styles/component/radio.css);
</style>