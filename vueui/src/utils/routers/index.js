import { createRouter, createWebHashHistory } from 'vue-router';
import TestCom from '../../components/TestCom.vue';
import ExemptionList from './../../views/ExemptionList.vue';

const routes = [
    // {   path: '/',  component: App    },
    {   path: '/exemption', component: ExemptionList  },
    {   path: '/test', component: TestCom  },
];
const router = createRouter ({
    history: createWebHashHistory(process.env.BASE_URL),
    routes
});

export default router;