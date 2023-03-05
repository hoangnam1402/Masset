const apiurl = "https://localhost:7150/"
const Endpoints = {
	authorize: "https://localhost:7150/api/authorize",
	me: "api/authorize/me",

	createUser: "api/users",
	getUser: apiurl+"api/user",
	getUserId: (id) => apiurl + `api/user/${id}`,

	getAsset: "api/asset",
	getAssetCategory: "api/asset/categories",
	// deleteAssetId: (id: number | string): string => `api/asset/${id}`,
	// getAssetId: (id: number | string): string => `api/asset/${id}`,

	// getAssignment: "api/assignment",
	// respondToAssignment: "api/assignment/respond",
	// getAssignmentId: (id: number | string): string => `api/assignment/${id}`,

	// createAssignment: "api/assignment",
	// getUserAssignment: "api/assignment/home",
	// deleteAssignmentId: (id: number | string): string => `api/assignment/${id}`,
};

export default Endpoints;
