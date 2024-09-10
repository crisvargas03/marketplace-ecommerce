import { createSlice } from '@reduxjs/toolkit';

export const authSilce = createSlice({
	name: 'auth',
	initialState: {
		status: 'authenticated', // 'authenticated', 'not-authenticated'
		user: {
			name: 'Cristian Vargas',
			userName: 'cvargas',
			id: '123456-BCDEF',
			isAdmin: false,
		}, // name, userName, id, isAdmin...
		errorMessage: undefined,
	},
	reducers: {
		onChecking: state => {
			state.status = 'checking';
			state.user = {};
			state.errorMessage = undefined;
		},
		onLogin: (state, { payload }) => {
			state.status = 'authenticated';
			state.user = payload;
			state.errorMessage = undefined;
		},
		onLogout: (state, { payload }) => {
			state.status = 'not-authenticated';
			state.user = {};
			state.errorMessage = payload;
		},
		clearErrorMessage: state => {
			state.errorMessage = undefined;
		},
	},
});

export const { onChecking, onLogin, onLogout, clearErrorMessage } =
	authSilce.actions;
