<template>
    <div class="m-filter-container">
        <div class="m-icon icon-24 icon-filter"></div>
        <input class="filter__input"/>
        <div class="filter__option">
            <div class="option__item">
                <input type="radio" name="filterOption">
                <div class="option__item--text m-icon">Xóa điều kiện lọc</div>
            </div>
             <div class="option__item">
                <input type="radio" name="filterOption" checked>
                <div class="option__item--text m-icon">Chứa</div>
            </div>
             <div class="option__item">
                <input type="radio" name="filterOption">
                <div class="option__item--text m-icon">Bằng</div>
            </div>
             <div class="option__item">
                <input type="radio" name="filterOption">
                <div class="option__item--text m-icon">Bắt đầu với</div>
            </div>
             <div class="option__item">
                <input type="radio" name="filterOption">
                <div class="option__item--text m-icon">Kết thúc với</div>
            </div>
             <div class="option__item">
                <input type="radio" name="filterOption">
                <div class="option__item--text m-icon">Không chứa</div>
            </div>
             <div class="option__item">
                <input type="radio" name="filterOption">
                <div class="option__item--text m-icon">Trống</div>
            </div>
             <div class="option__item">
                <input type="radio" name="filterOption">
                <div class="option__item--text m-icon">Không trống</div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: "MFilter"
}
</script>

<style scoped>
@import url(../../styles/component/filter.css);
</style>