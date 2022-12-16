<template>
  <div class="m-input-container">
    <label v-if="label" for="">{{label}}
        <span v-if="isRequired" style="color: var(--notice-red);">*</span>
    </label>
    <input class="m-input text-input" type="text" :readonly="isReadOnly" :disabled="isDisabled"/>
  </div>
</template>

<script>
export default {
    name: "MInput",
    
    props: {
      label: String, 
      isReadonly: {
        type: Boolean,
        default: false 
      },
      isRequired: {
        type: Boolean,
        default: false
      },
      isDisabled: {
        type: Boolean,
        default: false
      }
    }
};
</script>

<style>
</style>