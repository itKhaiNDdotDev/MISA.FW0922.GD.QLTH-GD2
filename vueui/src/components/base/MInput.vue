<template>
  <div class="m-input-container">
    <label for="">{{label}}
        <span v-if="isRequired" style="color: var(--notice-red);">*</span>
    </label>
    <input class="m-input text-input" type="text" :readonly="isReadOnly"/>
  </div>
</template>

<script>
export default {
    name: "MInput",
    
    props: ["label", "isReadOnly", "isRequired"]
};
</script>

<style>
</style>