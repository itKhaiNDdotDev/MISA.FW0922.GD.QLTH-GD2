import { createRouter, createWebHashHistory } from 'vue-router'
import TestCom from '../../components/TestCom.vue'

const routes = [
    // {   path: '/',  component: App    },
    {   path: '/test', component: TestCom  },
];
const router = createRouter ({
    history: createWebHashHistory(process.env.BASE_URL),
    routes
});

export default router;