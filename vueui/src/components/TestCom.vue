<template>
    <div class="container">
        <div>
            <br>
            <label for="">1. Icons: </label>
            <div class="m-icon icon-40 icon-edit"></div>
            <div class="m-icon icon-40 icon-filter"></div>
            <div class="m-icon icon-40 icon-nhapkhau"></div>
            <div class="m-icon icon-40 icon-duplicate"></div>
            <div class="m-icon icon-40 icon-print"></div>
            <div class="m-icon icon-40 icon-toast-warning"></div>
            <div class="m-icon icon-40 icon-logo-khoanthu"></div>
            <div class="m-icon icon-40 icon-sidebar"></div>
            <div class="m-icon icon-40 icon-kehoachthu"></div>
            <div class="m-icon icon-40 icon-quanlythu"></div>
            <div class="m-icon icon-40 icon-hoadon"></div>
            <div class="m-icon icon-40 icon-payment"></div>
            <div class="m-icon icon-40 icon-daotaoemis"></div>
            <div class="m-icon icon-40 icon-sothu"></div>
            <div class="m-icon icon-40 icon-print"></div>
            <br>
        </div>

        <div>
            <br>
            <label for="">2. Checkbox:</label>
            <MCheckbox/>
            <br>
        </div>

        <div>
            <br>
            <label for="">3. Radio:</label>
            <MRadio name="Khai"/>
            <MRadio name="Khai"/>
            <MRadio name="Khai"/>
            <br>
        </div>

        <div>
            <br>
            <label for="">4. Button:</label>
            <div class="m-button text-button btn-green">Thêm</div>
            <div class="m-button text-button btn-green">Thêm nhanh</div>
            <div class="m-button text-button btn-light">Đóng</div>
            <div class="m-button icon-button btn-light m-icon icon-delete-32"></div>
            <br>
        </div>

        <div>
            <br>
            <label for="">5. Input:</label>
            <m-input label="Họ vè tên" isRequired="true" isReadOnly="true"></m-input>
            <input type="date">
            <br>
        </div>

        <div>
            <br>
            <label for="">6. Dropdown:</label>
            <MDropdown label="Họ và tên"/>
            <br>
        </div>

        <div>
            <br>
            <label for="">7. Comnobox kèm error input:</label>
            <MCombobox label="Họ và tên" isRequired="true" :errorState="errorInputSate"/>
            <br>
        </div>

        <div>
            <br>
            <label for="">8. Filter:</label>
            <MFilter/>
            <br>
        </div>

        <div>
            <br>
            <label for="">9. Loader, Dialog, Toast:</label>
            <MLoader/>
            <MDialog v-if="isShowDialog" dialogMsg="Chi tiet thong bao tren Dialog" @onClose="onCloseDialog"/>
            <div class="toasts-container">
                <MToast toastType="1" toastMsg="Chi tiet toast messsage"/>
            </div>
            <br>
        </div>
    </div>
</template>


<script>
import MCheckbox from "./base/MCheckbox.vue";
import MRadio from "./base/MRadio.vue";
import MInput from "./base/MInput.vue"
import MDropdown from "./base/MDropdown.vue";
import MCombobox from "./base/MCombobox.vue";
import MFilter from "./base/MFilter.vue";
import MLoader from "./base/MLoader.vue";
import MDialog from "./base/MDialog.vue";
import MToast from "./base/MToast.vue";

export default {
    name: "TestCom",
    components: {
        MCheckbox,
        MRadio,
        MInput,
        MDropdown,
        MCombobox,
        MFilter,
        MLoader,
        MDialog,
        MToast
    },

    data() {
        return {
            isShowDialog: true,
            errorInputSate: {
                isError: true,
                message: "Có lỗi rồi"
            }
        }
    },

    methods: {
        onCloseDialog() {
            this.isShowDialog = false;
        }
    },
};
</script>


<style scoped>
.container {
  background-color: var(--white);
  margin: 16px;
  height: 100%;
}

.container > div {
    display: flex;
}
</style>