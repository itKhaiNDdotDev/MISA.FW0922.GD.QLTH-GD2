<template>
  <div class="m-input-container">
    <label for="">{{label}}
        <span v-if="isRequired" style="color: var(--notice-red);">*</span>
    </label>
    <div class="m-dropdown">
      <button class="m-icon icon-28 icon-down"></button>
      <input type="text" class="m-input" readonly
        :value="value"
      />
      <div class="dropdown__option">
        <div class="dropdown__option--item">Option 1</div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "MDropdown",

  props: ["label", "isRequired", "value"]
};
</script>

<style scoped>
@import url(../../styles/component/dropdown.css);
</style>