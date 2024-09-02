import { Grid, Input } from '@chakra-ui/react';
import { ProductsList } from '../components';

export function Home() {
	return (
		<Grid marginY={10} marginX={15}>
			<header style={{ marginBottom: '20px' }}>
				<Input placeholder='Search for something...' />
			</header>
			<main>
				<ProductsList />
			</main>
		</Grid>
	);
}
