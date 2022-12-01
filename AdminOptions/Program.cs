using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdminOptions {
	class Program {
		private static void updateRole() {
			Console.Write("Введите логин: ");
			var login = Console.ReadLine();
			Console.Write("Введите ур. полномочий(0 - пользователь, 1 - администратор): ");
			int roleI;
			if(int.TryParse(Console.ReadLine(), out roleI)) {
				Accounts.ManagementRole role;
				if(roleI == 0) role = Accounts.ManagementRole.user;
				else if(roleI == 1) role = Accounts.ManagementRole.admin;
				else goto end;
				
				var result = ServerQuery<AdminMessaging.Messaging>.Create("net.tcp://localhost:8080/admin")
					.attempt((it) => it.updateRole(login, role));
				
				if(result) Console.WriteLine("Роль обновлена");
				else Console.WriteLine("Роль НЕ обновлена: " + result.f.Message);

				return;
			}

			end:
			Console.WriteLine("Неправильная роль");
		}

		static void Main(string[] args) {
			while(true) { 
				Console.Write(
					"0. Выйти\n"
					+ "1. Изменить полномочия аккаунта\n"
					+ "Введите комманду: "
				);
				int res;
				if(int.TryParse(Console.ReadLine(), out res)) {
					if(res == 0) return;
					else if(res == 1) {
						updateRole();
						continue;
					}
				}

				Console.WriteLine("Команда не распознана. Повторите ввод");
			}
		}
	}
}
