/* eslint-disable react/prop-types */
import { Badge, Stack } from '@chakra-ui/react';

export function CategoriesBadges({ fontSize = 'xs', categories = [] }) {
	return (
		<Stack justifyContent={'center'} direction='row'>
			{categories.map(category => (
				<Badge
					fontSize={fontSize}
					key={category}
					variant='subtle'
					colorScheme='blue'>
					{category}
				</Badge>
			))}
		</Stack>
	);
}
