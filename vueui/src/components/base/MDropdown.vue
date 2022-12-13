<template>
  <div class="m-input-container">
    <label for="">{{label}}
        <span v-if="isRequired" style="color: var(--notice-red);">*</span>
    </label>
    <div class="m-dropdown" @click="toggleDropdown">
      <button class="m-icon icon-28 icon-down"></button>
      <input type="text" class="m-input" readonly
        :value="value"
      />
      <div class="dropdown__option"
        v-if="isShowOption"
      >
        <div class="dropdown__option--item">Option 1</div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "MDropdown",

  props: ["label", "isRequired", "value"],
  data() {
    return {
      isShowOption: false
    }
  },

  methods: {
    /**
     * Ẩn hiện danh sách lựa chọn của Dropdown, Combobox
     * Author: KhaiND (13/12/2022)
     */
    toggleDropdown() {
      this.isShowOption = !this.isShowOption;
    }
  },
};
</script>

<style scoped>
@import url(../../styles/component/dropdown.css);
</style>