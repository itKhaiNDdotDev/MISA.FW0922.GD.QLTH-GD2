<template>
  <div class="m-input-container" id="elDropdown">
    <label v-if="label" for="">
      {{label}}
      <span v-if="isRequired" style="color: var(--notice-red);">*</span>
    </label>
    <div class="m-dropdown" @click="onToggleDropdown(null)" ref="element">
      <!-- SỰ KIỆN BLUR -->
      <button class="m-icon icon-28 icon-down" v-if="!isDisabled"></button>
      <input v-if="isReadOnly" type="text" class="m-input" :readonly="true" :value="value"/> <!-- CHỈ DÙNG CHO Ô NĂM HỌC -->
      <input v-else type="text" class="m-input" ref="input"
        :readonly="isReadonly" :disabled="isDisabled" v-model="keyword"
        :class="{errorInput:isError}"
        :tabindex="tabIndex"
        @input ="onGetAPIData"
        @blur="onBlur"
      />
      
      <div class="m-error-message" v-if="isError">
        <div class="error-text">{{errorMsg}}</div>
        <div class="error-arrow"></div>
      </div>

      <div class="dropdown__option border-radius" v-if="!isDisabled&&isShowOption" id="dropdownOption">
        <table class="border-radius" v-if="!propData">
          <thead v-if="optionHeader.length > 1">
            <tr>
              <th v-for="(item, index) in optionHeader" :key="index">{{item.propTitle}}</th>
            </tr>
          </thead>
          <tbody> 
            <tr v-for="(item, index) in optionData" :key="index" @click="onToggleDropdown(item)">
              <td v-for="(itemData, index) in optionHeader" :key="index">
                <span v-if="itemData.propType == Date">{{formatDate(item[itemData.propName])}}</span>
                <span v-else>{{item[itemData.propName]}}</span>
              </td>
            </tr>
          </tbody>
        </table>
        
        <div class="option__item" v-else v-for="(item, index) in propData" :key="index" @click="onToggleDropdown(item)">
          {{item}}
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import { BASE_URL } from "./../../utils/constants/api";
import { formatDate } from "./../../utils/format-data";

export default {
  name: "MDropdown",
  el: "elDropdown",

  props: {
    label: String,
    isRequired: Boolean,
    isReadOnly: Boolean,
    isDisabled: Boolean,
    optionEnpoint: Object,
    optionHeader: Object,
    value: String,
    propData: Object,
    isAutoFocus: Boolean,
    isError: Boolean,
    errorMsg: String,
    tabIndex: Number
  },
  data() {
    return {
      isShowOption: false,
      optionData: [],
      keyword: this.value
    }
  },

  methods: {
    /**
     * Ẩn hiện danh sách lựa chọn của Dropdown, Combobox
     * Author: KhaiND (13/12/2022)
     */
    onToggleDropdown(item) {
      if(item != undefined) {
        this.keyword = this.propData ? item : item[this.optionHeader[0].propName];
        console.log(item);
        this.$emit("getSelected", item);
        this.isShowOption = false;
      }
      this.isShowOption = !this.isShowOption;
      if(this.isShowOption) {
        this.$refs.input.focus();
        this.onGetAPIData();
      }
    },

    //Load API
    onGetAPIData() {
      this.isShowOption = true;
      var url = BASE_URL + this.optionEnpoint + "/search"
      try {
        if(this.propData) {
          this.optionData = this.propData;
        }
        else {
          if(this.keyword) {
            url = url + "?keyword=" + this.keyword
          }
          axios.get(url).then((response) => {
            this.optionData = response.data;
            if(this.optionData.length < 1) {
              this.isShowOption = false;
            }
          });
        }
      }
      catch(error) {
        console.log(error);
        // Gửi STATE lỗi về cha
      }
    },

    /**
     * Gọi hàm định dạng ngày thành DD/MM/YYYY
     * @param {String} value - chuỗi giá trị thời gian cần định dạng
     * @returns chuỗi giá trị ngày đã định dạng
     * Author: KhaiND (26/12/2022)
     */
    formatDate(value) {
        return formatDate(value);
    },

    setKeyword(value) {
      this.keyword = value;
    },

    onBlur(event) {
      this.$emit("onBlur", event);
    },

    onFocus() {
      this.$refs.input.focus();
    }
  },

  created() {
     window.addEventListener("click", (event) => {
          if (!this.$el.contains(event.target)) {
            this.isShowOption = false;
            this.$emit("onFocusOut");
          }
        });
  },

  mounted() {
    if(this.isAutoFocus) {
      this.$refs.input.focus();
    }
  },

  watch: {
    value(value) {
      //alert(value);
      this.keyword = value;
      console.log(value);
    },

    keyword(value) {
      this.$emit("getKeyword", value);
    }
  }
};
</script>

<style scoped>
@import url(../../styles/component/dropdown.css);

.dropdown__option {
  z-index: 2;
  width: max-content;
  min-width: 100%;
}

.dropdown__option table thead {
  z-index: 1;
}

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