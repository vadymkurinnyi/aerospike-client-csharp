/*
 * Aerospike Client - C# Library
 *
 * Copyright 2013 by Aerospike, Inc. All rights reserved.
 *
 * Availability of this source code to partners and customers includes
 * redistribution rights covered by individual contract. Please check your
 * contract for exact rights and responsibilities.
 */
using System.Linq;

namespace Aerospike.Client
{
	/// <summary>
	/// Unique record identifier. Records can be identified using a specified namespace,
	/// an optional set name, and a user defined key which must be unique within a set.
	/// Records can also be identified by namespace/digest which is the combination used 
	/// on the server.
	/// </summary>
	public sealed class Key
	{
		/// <summary>
		/// Namespace. Equivalent to database name.
		/// </summary>
		public readonly string ns;

		/// <summary>
		/// Optional set name. Equivalent to database table.
		/// </summary>
		public readonly string setName;

		/// <summary>
		/// Unique server hash value generated from set name and user key.
		/// </summary>
		public readonly byte[] digest;

		/// <summary>
		/// Original user key. This key is immediately converted to a hash digest.
		/// This key is not used or returned by the server.  If the user key needs 
		/// to persist on the server, the key should be explicitly stored in a bin.
		/// </summary>
		public readonly object userKey;

		/// <summary>
		/// Initialize key from namespace, optional set name and user key.
		/// The set name and user defined key are converted to a digest before sending to the server.
		/// The server handles record identifiers by digest only.
		/// If the user key needs to be stored on the server, the key should be stored in a bin.
		/// </summary>
		/// <param name="ns">namespace</param>
		/// <param name="setName">optional set name, enter null when set does not exist</param>
		/// <param name="key">user defined unique identifier within set.</param>
		/// <exception cref="AerospikeException">if digest computation fails</exception>
		public Key(string ns, string setName, Value key)
		{
			this.ns = ns;
			this.setName = setName;
			this.userKey = key;
			digest = ComputeDigest(setName, key);
		}

		/// <summary>
		/// Initialize key from namespace, optional set name and user key.
		/// The set name and user defined key are converted to a digest before sending to the server.
		/// The server handles record identifiers by digest only.
		/// </summary>
		/// <param name="ns">namespace</param>
		/// <param name="setName">optional set name, enter null when set does not exist</param>
		/// <param name="key">user defined unique identifier within set.</param>
		/// <exception cref="AerospikeException">if digest computation fails</exception>
		public Key(string ns, string setName, string key)
		{
			this.ns = ns;
			this.setName = setName;
			this.userKey = key;
			digest = ComputeDigest(setName, new Value.StringValue(key));
		}

		/// <summary>
		/// Initialize key from namespace, optional set name and user key.
		/// The set name and user defined key are converted to a digest before sending to the server.
		/// The server handles record identifiers by digest only.
		/// If the user key needs to be stored on the server, the key should be stored in a bin.
		/// </summary>
		/// <param name="ns">namespace</param>
		/// <param name="setName">optional set name, enter null when set does not exist</param>
		/// <param name="key">user defined unique identifier within set.</param>
		/// <exception cref="AerospikeException">if digest computation fails</exception>
		public Key(string ns, string setName, byte[] key)
		{
			this.ns = ns;
			this.setName = setName;
			this.userKey = key;
			digest = ComputeDigest(setName, new Value.BytesValue(key));
		}

		/// <summary>
		/// Initialize key from namespace, optional set name and user key.
		/// The set name and user defined key are converted to a digest before sending to the server.
		/// The server handles record identifiers by digest only.
		/// If the user key needs to be stored on the server, the key should be stored in a bin.
		/// </summary>
		/// <param name="ns">namespace</param>
		/// <param name="setName">optional set name, enter null when set does not exist</param>
		/// <param name="key">user defined unique identifier within set.</param>
		/// <exception cref="AerospikeException">if digest computation fails</exception>
		public Key(string ns, string setName, long key)
		{
			this.ns = ns;
			this.setName = setName;
			this.userKey = key;
			digest = ComputeDigest(setName, new Value.LongValue(key));
		}

		/// <summary>
		/// Initialize key from namespace, optional set name and user key.
		/// The set name and user defined key are converted to a digest before sending to the server.
		/// The server handles record identifiers by digest only.
		/// If the user key needs to be stored on the server, the key should be stored in a bin.
		/// </summary>
		/// <param name="ns">namespace</param>
		/// <param name="setName">optional set name, enter null when set does not exist</param>
		/// <param name="key">user defined unique identifier within set.</param>
		/// <exception cref="AerospikeException">if digest computation fails</exception>
		public Key(string ns, string setName, ulong key)
		{
			this.ns = ns;
			this.setName = setName;
			this.userKey = key;
			digest = ComputeDigest(setName, new Value.UnsignedLongValue(key));
		}

		/// <summary>
		/// Initialize key from namespace, optional set name and user key.
		/// The set name and user defined key are converted to a digest before sending to the server.
		/// The server handles record identifiers by digest only.
		/// If the user key needs to be stored on the server, the key should be stored in a bin.
		/// </summary>
		/// <param name="ns">namespace</param>
		/// <param name="setName">optional set name, enter null when set does not exist</param>
		/// <param name="key">user defined unique identifier within set.</param>
		/// <exception cref="AerospikeException">if digest computation fails</exception>
		public Key(string ns, string setName, int key)
		{
			this.ns = ns;
			this.setName = setName;
			this.userKey = key;
			digest = ComputeDigest(setName, new Value.IntegerValue(key));
		}

		/// <summary>
		/// Initialize key from namespace, optional set name and user key.
		/// The set name and user defined key are converted to a digest before sending to the server.
		/// The server handles record identifiers by digest only.
		/// If the user key needs to be stored on the server, the key should be stored in a bin.
		/// </summary>
		/// <param name="ns">namespace</param>
		/// <param name="setName">optional set name, enter null when set does not exist</param>
		/// <param name="key">user defined unique identifier within set.</param>
		/// <exception cref="AerospikeException">if digest computation fails</exception>
		public Key(string ns, string setName, uint key)
		{
			this.ns = ns;
			this.setName = setName;
			this.userKey = key;
			digest = ComputeDigest(setName, new Value.UnsignedIntegerValue(key));
		}

		/// <summary>
		/// Initialize key from namespace, optional set name and user key.
		/// The set name and user defined key are converted to a digest before sending to the server.
		/// The server handles record identifiers by digest only.
		/// If the user key needs to be stored on the server, the key should be stored in a bin.
		/// </summary>
		/// <param name="ns">namespace</param>
		/// <param name="setName">optional set name, enter null when set does not exist</param>
		/// <param name="key">user defined unique identifier within set.</param>
		/// <exception cref="AerospikeException">if digest computation fails</exception>
		public Key(string ns, string setName, short key)
		{
			this.ns = ns;
			this.setName = setName;
			this.userKey = key;
			digest = ComputeDigest(setName, new Value.ShortValue(key));
		}

		/// <summary>
		/// Initialize key from namespace, optional set name and user key.
		/// The set name and user defined key are converted to a digest before sending to the server.
		/// The server handles record identifiers by digest only.
		/// If the user key needs to be stored on the server, the key should be stored in a bin.
		/// </summary>
		/// <param name="ns">namespace</param>
		/// <param name="setName">optional set name, enter null when set does not exist</param>
		/// <param name="key">user defined unique identifier within set.</param>
		/// <exception cref="AerospikeException">if digest computation fails</exception>
		public Key(string ns, string setName, ushort key)
		{
			this.ns = ns;
			this.setName = setName;
			this.userKey = key;
			digest = ComputeDigest(setName, new Value.UnsignedShortValue(key));
		}

		/// <summary>
		/// Initialize key from namespace, optional set name and user key.
		/// The set name and user defined key are converted to a digest before sending to the server.
		/// The server handles record identifiers by digest only.
		/// If the user key needs to be stored on the server, the key should be stored in a bin.
		/// </summary>
		/// <param name="ns">namespace</param>
		/// <param name="setName">optional set name, enter null when set does not exist</param>
		/// <param name="key">user defined unique identifier within set.</param>
		/// <exception cref="AerospikeException">if digest computation fails</exception>
		public Key(string ns, string setName, bool key)
		{
			this.ns = ns;
			this.setName = setName;
			this.userKey = key;
			digest = ComputeDigest(setName, new Value.BooleanValue(key));
		}

		/// <summary>
		/// Initialize key from namespace, optional set name and user key.
		/// The set name and user defined key are converted to a digest before sending to the server.
		/// The server handles record identifiers by digest only.
		/// If the user key needs to be stored on the server, the key should be stored in a bin.
		/// </summary>
		/// <param name="ns">namespace</param>
		/// <param name="setName">optional set name, enter null when set does not exist</param>
		/// <param name="key">user defined unique identifier within set.</param>
		/// <exception cref="AerospikeException">if digest computation fails</exception>
		public Key(string ns, string setName, byte key)
		{
			this.ns = ns;
			this.setName = setName;
			this.userKey = key;
			digest = ComputeDigest(setName, new Value.ByteValue(key));
		}

		/// <summary>
		/// Initialize key from namespace, optional set name and user key.
		/// The set name and user defined key are converted to a digest before sending to the server.
		/// The server handles record identifiers by digest only.
		/// If the user key needs to be stored on the server, the key should be stored in a bin.
		/// </summary>
		/// <param name="ns">namespace</param>
		/// <param name="setName">optional set name, enter null when set does not exist</param>
		/// <param name="key">user defined unique identifier within set.</param>
		/// <exception cref="AerospikeException">if digest computation fails</exception>
		public Key(string ns, string setName, sbyte key)
		{
			this.ns = ns;
			this.setName = setName;
			this.userKey = key;
			digest = ComputeDigest(setName, new Value.SignedByteValue(key));
		}

		/// <summary>
		/// Initialize key from namespace, digest and optional set name.
		/// </summary>
		/// <param name="ns">namespace</param>
		/// <param name="digest">unique server hash value</param>
		/// <param name="setName">optional set name, enter null when set does not exist</param>
		public Key(string ns, byte[] digest, string setName)
		{
			this.ns = ns;
			this.digest = digest;
			this.setName = setName;
			this.userKey = null;
		}

		/// <summary>
		/// Hash lookup uses namespace and digest.
		/// </summary>
		public override int GetHashCode()
		{
			int result = 1;
			foreach (byte element in digest)
			{
				result = 31 * result + element;
			}
			return 31 * result + ns.GetHashCode();
		}

		/// <summary>
		/// Equality uses namespace and digest.
		/// </summary>
		public override bool Equals(object obj)
		{
			Key other = (Key) obj;

			if (digest.Length != other.digest.Length)
			{
				return false;
			}

			for (int i = 0; i < digest.Length; i++)
			{
				if (digest[i] != other.digest[i])
				{
					return false;
				}
			}
			return ns.Equals(other.ns);
		}

		/// <summary>
		/// Generate unique server hash value from set name, key type and user defined key.  
		/// The hash function is RIPEMD-160 (a 160 bit hash).
		/// </summary>
		/// <param name="setName">optional set name, enter null when set does not exist</param>
		/// <param name="key">record identifier, unique within set</param>
		/// <returns>unique server hash value</returns>
		/// <exception cref="AerospikeException">if digest computation fails</exception>
		public static byte[] ComputeDigest(string setName, Value key)
		{
			int keyType = key.Type;

			if (keyType == ParticleType.NULL)
			{
				throw new AerospikeException(ResultCode.PARAMETER_ERROR, "Invalid key: null");
			}

			byte[] buffer = ThreadLocalData1.GetBuffer();
			int offset = ByteUtil.StringToUtf8(setName, buffer, 0);
			buffer[offset++] = (byte)keyType;
			offset += key.Write(buffer, offset);

			return Hash.Algorithm.ComputeHash(buffer, 0, offset);
		}
	}
}