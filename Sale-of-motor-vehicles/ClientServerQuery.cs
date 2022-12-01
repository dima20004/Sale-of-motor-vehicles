namespace Sale_of_motor_vehicles {
	public static class ClientServerQuery {
		public static ClientMessaging.Messaging Create() {
			return Common.ServerQuery<ClientMessaging.Messaging>.Create("net.tcp://localhost:8080/client");
		}
	}
}
