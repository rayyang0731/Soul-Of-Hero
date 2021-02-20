namespace KiwiFramework.Core {
	/// <summary>
	/// 唯一标识符生成器
	/// </summary>
	public static class GUIDHelper {
		/// <summary>
		/// 获取唯一标识符
		/// </summary>
		/// <returns></returns>
		public static string Get () {
			return System.Guid.NewGuid ().ToString ("D");
		}
	}
}