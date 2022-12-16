<template>
  <div class="m-input-container">
    <label v-if="label" for="">
      {{label}}
      <span v-if="isRequired" style="color: var(--notice-red);">*</span>
    </label>
    <div class="m-dropdown" @click="toggleDropdown">
      <button class="m-icon icon-28 icon-down"></button>
      <input type="text" class="m-input" :readonly="isReadonly" :value="value"/>
      <div class="dropdown__option border-radius" v-if="isShowOption">
        <table v-if="numberColumn > 1" class="border-radius">
          <thead>
            <tr>
              <th>ID</th>
              <th>Name</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(item, index) in optionData" :key="index">
              <td>{{item.id}}</td>
              <td>{{item.name}}</td>
              <td>Test test test test test</td>
              <td>Test test test test test</td>
              <td>Test test</td>
            </tr>
          </tbody>
        </table>
        <div class="option__item" v-else v-for="(item, index) in optionData" :key="index">{{item.name}}</div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "MDropdown",

  props: ["label", "isRequired", "isReadOnly", "numberColumn", "value"],
  data() {
    return {
      isShowOption: false,
      optionData: [
        {
          id: 1,
          name: "Option 1"
        },
        {
          id: 2,
          name: "Option 2"
        },
        {
          id: 3,
          name: "Option 3"
        },
        {
          id: 4,
          name: "Option 4"
        },
        {
          id: 5,
          name: "Option 5"
        },
        {
          id: 6,
          name: "Option 6"
        },
      ]
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