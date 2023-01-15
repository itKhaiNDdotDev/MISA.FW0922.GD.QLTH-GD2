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
    /**
     * Sự kiện khi thay đổi giá trị chọn ở radio input thì truyền giá trị đó lên cho Component cha
     * @param {@event} event - Sự kiện tương ứng ô radio input có tương tác thay đổi giá trị
     * Author: KhaiND (22/12/2022)
     */
    onChange(event) {
      try {
        this.$emit("changeViewMode", event.target.value);
      }
      catch(error) {
        console.log(error);
        //Trả STATE báo lỗi về cha
      }
    }
  }
};
</script>

<style scoped>
    @import url(../../styles/component/radio.css);
</style>