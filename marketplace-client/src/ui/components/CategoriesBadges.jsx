import { Badge, Stack } from '@chakra-ui/react';

export function CategoriesBadges({ categories = [] }) {
	return (
		<Stack justifyContent={'center'} direction='row'>
			{categories.map(category => (
				<Badge key={category} variant='subtle' colorScheme='blue'>
					{category}
				</Badge>
			))}
		</Stack>
	);
}
