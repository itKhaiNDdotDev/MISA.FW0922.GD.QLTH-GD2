<template>
  <div class="m-input-container">
    <label v-if="label" for="">
      {{label}}
      <span v-if="isRequired" style="color: var(--notice-red);">*</span>
    </label>
    <div class="m-dropdown" @click="onToggleDropdown(null)">
      <!-- SỰ KIỆN BLUR -->
      <button class="m-icon icon-28 icon-down"></button>
      <input v-if="isReadOnly" type="text" class="m-input" ref="input" :readonly="true" :value="value"/> <!-- CHỈ DÙNG CHO Ô NĂM HỌC -->
      <input v-else type="text" class="m-input" ref="input" :readonly="isReadonly" v-model="keyword" @input ="onGetAPIData"/>
      <div class="dropdown__option border-radius" v-if="isShowOption">
        <table v-if="optionHeader.length > 1" class="border-radius">
          <thead>
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
        <div class="option__item" v-else v-for="(item, index) in optionData" :key="index" @click="onToggleDropdown(item)">
          {{item.name}}
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

  props: ["label", "isRequired", "isReadOnly", "optionEnpoint", "optionHeader", "value", "propData"],
  data() {
    return {
      isShowOption: false,
      optionData: [],
      keyword: ""
    }
  },

  methods: {
    /**
     * Ẩn hiện danh sách lựa chọn của Dropdown, Combobox
     * Author: KhaiND (13/12/2022)
     */
    onToggleDropdown(item) {
      if(item != undefined) {
        this.keyword = item[this.optionHeader[0].propName];
        this.$emit("getSelected", item);
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
    }
  },
};
</script>

<style scoped>
@import url(../../styles/component/dropdown.css);
</style>