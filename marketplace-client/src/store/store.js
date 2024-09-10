import { configureStore } from '@reduxjs/toolkit';
import { authSilce } from './auth/authSlice';

export const store = configureStore({
	reducer: {
		auth: authSilce.reducer,
	},
});
