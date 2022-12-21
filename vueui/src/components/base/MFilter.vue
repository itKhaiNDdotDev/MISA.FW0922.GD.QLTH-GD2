<template>
    <div class="m-filter-container">
        <div class="m-icon icon-24 icon-filter" @click="toggleFilter"></div>
        <input v-if="isInputDate" class="filter__input" />
        <input v-else class="filter__input" type="text"/>
        <div class="filter__option" v-if="isShowOption">
            <div class="option__item">
                <input type="radio" name="filterOption">
                <div class="option__item--text m-icon">{{filterOption.ClearOption}}</div>
            </div>
             <div class="option__item">
                <input type="radio" name="filterOption" checked>
                <div class="option__item--text m-icon">{{filterOption.Contain}}</div>
            </div>
             <div class="option__item">
                <input type="radio" name="filterOption">
                <div class="option__item--text m-icon">{{filterOption.Equal}}</div>
            </div>
             <div class="option__item">
                <input type="radio" name="filterOption">
                <div class="option__item--text m-icon">{{filterOption.Begin}}</div>
            </div>
             <div class="option__item">
                <input type="radio" name="filterOption">
                <div class="option__item--text m-icon">{{filterOption.End}}</div>
            </div>
             <div class="option__item">
                <input type="radio" name="filterOption">
                <div class="option__item--text m-icon">{{filterOption.NotContain}}</div>
            </div>
             <div class="option__item">
                <input type="radio" name="filterOption">
                <div class="option__item--text m-icon">{{filterOption.Blank}}</div>
            </div>
             <div class="option__item">
                <input type="radio" name="filterOption">
                <div class="option__item--text m-icon">{{filterOption.NotBlank}}</div>
            </div>
        </div>
    </div>
</template>

<script>
import Resources from "./../../utils/resources/common";

export default {
    name: "MFilter",

    props: ["isInputDate"],
    data() {
        return {
            isShowOption: false,
            filterOption: Resources.Filter.Text
        }
    },

    methods: {
        /**
         * Thực hiện ẩn hiện danh sách lựa chọn cho mode filter
         * Author: KhaiND (14/12/2022)
         */
        toggleFilter() {
            this.isShowOption = !this.isShowOption;
        }
    },
}
</script>

<style scoped>
@import url(../../styles/component/filter.css);
</style>