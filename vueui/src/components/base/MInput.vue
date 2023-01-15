<template>
  <div class="m-input-container">
    <label v-if="label" for=""
      >{{ label }}
      <span v-if="isRequired" style="color: var(--notice-red)">*</span>
    </label>

    <input
      class="m-input text-input"
      :type="type"
      ref="input"
      :value="value"
      :readonly="isReadOnly"
      :disabled="isDisabled"
      @input="onChangeInput"
    />

    <div v-if="type == typeNumber" class="input__unit unit--pc">%</div>
    <div v-if="type == typeNumber" class="input__unit unit--d">đ</div>
  </div>
</template>

<script>
export default {
  name: "MInput",

  data() {
    return {
      typeNumber: "number",
    };
  },
  props: {
    label: String,
    isReadonly: {
      type: Boolean,
      default: false,
    },
    isRequired: {
      type: Boolean,
      default: false,
    },
    isDisabled: {
      type: Boolean,
      default: false,
    },
    value: String,
    type: String,
    isAutoFocus: Boolean,
  },

  methods: {
    onChangeInput(event) {
      this.$emit("onChangeInput", event.target.value);
    }
  },

  mounted() {
    if (this.isAutoFocus) {
      this.$refs.input.focus();
    }
  },
};
</script>

<style scoped>
input[type="number"] {
  text-align: right;
  padding-right: 40px;
}

.input__unit {
  position: absolute;
  height: 30px;
  display: flex;
  align-items: center;
  padding: 0px 4px;
  top: 1px;
}

.unit--pc {
  background-color: var(--main-green);
  color: var(--white);
  right: 16px;
}
.unit--d {
  right: 1px;
}
</style>>