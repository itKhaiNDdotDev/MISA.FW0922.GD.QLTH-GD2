<template>
  <div class="m-combo-container">
    <div class="m-input-container">
      <label for="">{{label}}
          <span v-if="isRequired" style="color: var(--notice-red);">*</span>
      </label>

      <div @click="toggleDropdown" class="m-dropdown">
        <button class="m-icon icon-28 icon-down"></button>
        <input type="text" class="m-input" :class="{errorInput:errorState.isError}"/>

        <div class="m-error-message" v-if="errorState.isError">
          <div class="error-text">{{errorState.message}}</div>
          <div class="error-arrow"></div>
        </div>
      </div>
    </div>

    <MInput v-for="(item, index) in opt.head.slice(1, opt.head.length)" :key="index"
      :label="item" :isReadOnly="true"
    />
    
    <table class="dropdown__option combobox__option"
      v-if="isShowOption"
    >
      <thead>
        <tr class="combobox__option--head">
          <th v-for="(item, index) in opt.head" :key="index">
            {{item}}
          </th>
        </tr>
      </thead>
      <tbody>
        <tr class="combobox__option--item" v-for="(item, index) in opt.data" :key="index">
          <td v-for="(itemName, subId) in item" :key="subId">
            {{itemName}}
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import MInput from "./MInput.vue";

export default {
    name: "MCombobox",
    components: {
      MInput
    },

    props: ["label", "isRequired", "errorState"], //errorState: {isError: Boolean, message: String}

    data() {
      return {
        isShowOption: false,
        opt: {
          head: [
            "Họ tên",
            "Ngày sinh",
            "Lớp"
          ],
          data: [
            {
              name: "KhaiND",
              date: "11/11/2111",
              class: "2/2"
            },
            {
              name: "KhaiND",
              date: "11/11/2111",
              class: "2/2"
            }
          ]
        }
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
    @import url(../../styles/component/combo.css);

    label { /*********************************NHOWS XOAS DDI NHEA */
      z-index: 0;
    }

    /**
    * Xử lý CSS error Input
    * Author: KhaiND (09/12/2022)
    */
    .errorInput {
    border-color: var(--notice-red) !important;
  }

  .m-error-message {
      background-color: var(--notice-red);
      color: var(--white);
      opacity: 90%;
      padding: 4px 8px;
      width: max-content;
      border-radius: 4px;
      position: absolute;
      left: calc(100% + 4px);
      top: 50%;
      transform: translate(0%, -50%);
      z-index: 1;
      display: none;
  }
  .m-input:hover ~ .m-error-message {
      display: block;
  }
  .m-input:focus ~ .m-error-message {
      display: block;
  }

  .m-error-message .error-arrow {
      width: 6px;
      height: 6px;
      position: absolute;
      background-color: inherit;
      top: 50%;
      left: 0;
      transform: translate(-50%, -50%) rotate(45deg);
      z-index: 0;
  }

  .m-error-message .error-text {
      position: relative;
      z-index: 1;
  }
</style>