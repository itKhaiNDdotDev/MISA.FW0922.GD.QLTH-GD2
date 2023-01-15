<template>
  <div class="m-checkbox">
    <input class="checkbox--real" type="checkbox"
      @change="onCheck" :checked="isChecked"
    />
    <div class="checkbox--pseudo"></div>
  </div>
</template>


<script>
export default {
    name: "MCheckbox",
    
    props: ["isChecked"],

    methods: {
      /**
       * Sự kiện khi check/uncheck trên ô checkbox
       * Author: KhaiND (26/12/20222)
       */
      onCheck() {
        this.$emit("onCheck");
      }
    },
};
</script>

<style scoped>
    @import url(../../styles/component/checkbox.css);
</style>