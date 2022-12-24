<template>
  <div class="m-radio">
    <input class="radio--real" type="radio" :name="name" :checked="isChecked" :value="value" @change="onChange"/>
    <div class="radio--pseudo"></div>
  </div>
</template>

<script>
export default {
  name: "MRadio",
  props: ["name", "isChecked", "value"],

  methods: {
    onChange(event) {
      this.$emit("changeViewMode", event.target.value);
    }
  }
};
</script>

<style scoped>
    @import url(../../styles/component/radio.css);
</style>